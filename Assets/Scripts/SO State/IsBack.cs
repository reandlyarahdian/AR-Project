using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isBack")]
public class IsBack : Decide
{
    public override bool Decision(CharacterSO character)
    {
        return character.isBack;
    }
}
