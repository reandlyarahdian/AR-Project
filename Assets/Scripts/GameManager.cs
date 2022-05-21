using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public Text[] texts;
    public Points[] points;
    public GateNFence[] gate;
    public GameObject Ball;
    public Text timeText;
    Vector3 mousePosition;
    float times = 140;
    int i = 1;
    int j = 0;
    int x = 2;
    int y = 3;
    Vector3 PlayerPos = new Vector3(0,0, 1.1f);
    Vector3 EnemyPos = new Vector3(0,0, 8.4f);
    Vector3 Pos = Vector3.zero;
    public Game game;
    MatchManager match;
    
    private void Start()
    {
        match = GetComponent<MatchManager>();
        game = match.side();
        CheckGame();
        SpawnBall(Pos);
    }

    private void Update()
    {
        SpawnCharacter(i, j, x, y);
        match.timer = timer();
    }
    void CheckGame()
    {
        switch (game)
        {
            case Game.Game1:
                i = 1;
                j = 0;
                x = 2;
                y = 3;
                Pos = PlayerPos;
                texts[0].text = "Player (Attacker)";
                texts[1].text = "Enemy (Defender)";
                gate[0].Attacker();
                gate[1].Defender();
                break;
            case Game.Game2:
                i = 0;
                j = 1;
                x = 3;
                y = 2;
                Pos = EnemyPos;
                texts[0].text = "Player (Defender)";
                texts[1].text = "Enemy (Attacker)";
                gate[1].Attacker();
                gate[0].Defender();
                break;
            case Game.Game3:
                j = 2;
                i = -1;
                gate[0].Attacker();
                gate[1].Defender();
                break;
        }
    }
    void SpawnCharacter(int enemy, int player, int PlayerPoint,int EnemyPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            mousePosition = hit.point;
            mousePosition.y = 0;
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.name == "Plane")
                {
                    if (mousePosition.z < 5)
                    {
                        GameObject obj = Instantiate(prefabs[player], hit.point, Quaternion.identity);
                        points[0].GetPoint(PlayerPoint);
                    }
                    else if (mousePosition.z > 5)
                    {
                        GameObject obj = Instantiate(prefabs[enemy], hit.point, Quaternion.identity);
                        points[1].GetPoint(EnemyPoint);
                    }
                }
            }
        }
    }

    float timer()
    {
        if(times >= 0)
        {
            timeText.text = ((int)times).ToString();
            return times -= Time.deltaTime;
        }
        return times = 0;
    }

    void SpawnBall(Vector3 center)
    {
        float minZ = center.z - 2.9f;
        float maxZ = center.z + 2.9f;
        float minX = center.x - 2f;
        float maxX = center.x + 2f;
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        GameObject obj = Instantiate(Ball, new Vector3(x, 0.15f, z), Quaternion.identity);
        obj.name = "Ball";
    }
}

public enum Game
{
    Game1,
    Game2,
    Game3
}
