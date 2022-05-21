using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSO : MonoBehaviour
{
    public StateSO remainS;
    public StateSO curentS;

    public CharacterController controller;

    public float TimeElapsed;

    public Vector3 startPosition;

    public GameObject ball;
    public GameObject ballHolder;
    public GameObject target;

    public Renderer renderer;
    public Material Inactive;
    public Material temp;

    public Side side;

    public bool isTouched;
    public bool isBack;
    public bool isInactive;

    private float power = 1.5f;
    float radius;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
        temp = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        curentS.UpdateState(this);
        isBack = transform.position == new Vector3(startPosition.x, transform.position.y, startPosition.z);
        Debug.Log(controller.isGrounded);
    }

    private void FixedUpdate()
    {
        if (side == Side.Defend)
        {
            float radar = Mathf.Sqrt(14f / Mathf.PI);
            radius = radar;
            Target(radar);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPosition, radius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterSO>() != null)
        {
            if (other.GetComponent<CharacterSO>().side != side)
            {
                isTouched = true;
                Ball.parent = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterSO>() != null)
        {
            if (other.GetComponent<CharacterSO>().side != side)
            {
                isTouched = false;
                Ball.parent = false;
            }
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body;
        if (hit.gameObject.GetComponent<Rigidbody>() != null)
        {
            body = hit.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.AddForce(dir * power * Time.deltaTime);
        }
    }

    public void Target(float radius)
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in col)
        {
            if (c.CompareTag("Attacker"))
            {
                target = c.gameObject;
            }
        }
    }

    public Gate gate(string tag)
    {
        Gate[] gates = FindObjectsOfType<Gate>();
        foreach (Gate g in gates)
            if (g.tag == tag)
                return g;
        return null;
    }

    public GameObject balls()
    {
        ball = FindObjectOfType<Ball>().gameObject;
        return ball;
    }

    public bool CheckCountDown(float duration)
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= duration)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Move(Vector3 target, float speed)
    {
        Vector3 targetPos = target - transform.position;
        targetPos = targetPos.normalized * speed;
        targetPos.y = -1;

        controller.Move(targetPos * Time.deltaTime);

        Quaternion quaternion = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime);
    }

    public void ChangeColor(Material material)
    {
        renderer.material = material;
    }

    public void TransitionToState(StateSO nextS)
    {
        if (nextS != remainS)
        {
            curentS = nextS;
            TimeElapsed = 0;
        }
    }
}
public enum Side
{
    Attack,
    Defend
}
