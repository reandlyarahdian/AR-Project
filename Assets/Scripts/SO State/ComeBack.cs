using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/ComeBack")]
public class ComeBack : Act
{
    public override void Action(CharacterSO character)
    {
        character.Move(character.startPosition, 2f);
        character.controller.skinWidth = 0.0001f;
        character.ChangeColor(character.Inactive);
    }
}
