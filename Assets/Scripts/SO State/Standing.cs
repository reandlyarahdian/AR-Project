using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/Standing")]
public class Standing : Act
{
    public override void Action(CharacterSO character)
    {

        character.controller.skinWidth = 0.1f;
        character.Move(character.transform.position, 0);
        character.ChangeColor(character.temp);
    }
}
