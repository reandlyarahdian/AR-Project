using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isAttacker")]
public class IsAttacker : Decide
{
    public override bool Decision(CharacterSO character)
    {
        return character.target != null;
    }
}
