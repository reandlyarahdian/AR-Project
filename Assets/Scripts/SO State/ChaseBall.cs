using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/ChaseBall")]
public class ChaseBall : Act
{
    public override void Action(CharacterSO character)
    {

        character.controller.skinWidth = 0.1f;
        character.Move(character.balls().transform.position - Vector3.forward * 0.271f, 1.5f);
        character.ChangeColor(character.temp);
        character.isInactive = false;
    }
}
