using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/ToAttacker")]
public class ToAttacker : Act
{
    public override void Action(CharacterSO character)
    {
        character.Move(character.target.transform.position, 1f);
    }
}
