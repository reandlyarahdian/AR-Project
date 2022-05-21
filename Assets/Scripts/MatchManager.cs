using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public static int Matches = 1;

    public static int Enemy = 0;
    public static int Player = 0;
    public static int Draw = 0;

    public float timer;
    Game game;

    private void Awake()
    {
        if(Matches == 6)
        {
            if(Enemy == Player)
            {
                game = Game.Game3;
            }
            else
            {
                game = Game.Game1;
                Matches = 1;
            }
        }
    }

    private void Update()
    {
        PlayerWins();
        DrawMatch();
        EnemyWins();
    }

    public Game side()
    {
        switch (Matches)
        {
            case 1:
                return Game.Game1;
            case 2:
                return Game.Game2;
            case 3:
                return Game.Game1;
            case 4:
                return Game.Game2;
            case 5:
                return Game.Game1;
            default: 
                return game;
        }
    }
    public void PlayerWins()
    {
        bool isWIn = FindObjectOfType<Ball>() == null;
        if (isWIn)
        {
            Player++;
            Restart();
        }
    }

    public void DrawMatch()
    {
        if(timer == 0)
        {
            Draw++;
            Restart();
        }
    }

    public void EnemyWins()
    {
        CharacterSO[] characters = FindObjectsOfType<CharacterSO>();
        foreach (CharacterSO character in characters)
        {
            if(character.side == Side.Attack)
            {
                if (!character.isInactive)
                {
                    return;
                }
                Enemy++;
                Restart();
            }
        }
    }
    void Restart()
    {
        Matches++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
