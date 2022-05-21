using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/Forward")]
public class Forward : Act
{
    private Vector3 move;
    public override void Action(CharacterSO character)
    {
        move = character.transform.position + Vector3.forward * 12f;
        character.Move(move, 1.5f);
    }
}
