using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/Inactive")]
public class InactiveSO : Act
{
    private Side side;
    public override void Action(CharacterSO character)
    {
        character.Move(character.transform.position, 0);
        character.controller.skinWidth = 0.0001f;
        character.ChangeColor(character.Inactive);
        character.target = null;
        character.isInactive = true;
    }
}
