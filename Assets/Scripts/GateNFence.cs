using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNFence : MonoBehaviour
{
    public Material attack;
    public Material defense;
    public void Attacker()
    {
        foreach(var m in GetComponentsInChildren<MeshRenderer>())
        {
            m.material = attack;
        }
        Gate gate = GetComponentInChildren<Gate>();
        gate.gameObject.tag = "Attacker";
        foreach (var t in GetComponentsInChildren<TriggerToDestroy>())
        {
            t.tag = "Defender";
        }
    }
    public void Defender()
    {
        foreach (var m in GetComponentsInChildren<MeshRenderer>())
        {
            m.material = defense;
        }
        Gate gate = GetComponentInChildren<Gate>();
        gate.gameObject.tag = "Defender";
        foreach(var t in GetComponentsInChildren<TriggerToDestroy>())
        {
            t.tag = "Attacker";
        }
    }
}
