using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool ball;
    public static bool parent;

    private void Update()
    {
        if (parent)
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            transform.parent = other.transform;
        }
    }
}
