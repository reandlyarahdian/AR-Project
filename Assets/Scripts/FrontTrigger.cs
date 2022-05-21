using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTrigger : MonoBehaviour
{
    public bool isBall;

    private void Update()
    {
        if (gameObject.GetComponentInChildren<Ball>())
        {
            isBall = true;
            Ball.ball = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isBall = true;
            Ball.ball = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isBall = true;
            Ball.ball = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isBall = false;
            Ball.ball = false;
        }
    }
}
