using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToDestroy : MonoBehaviour
{
    public string tag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Destroy(other.gameObject);
        }
    }
}
