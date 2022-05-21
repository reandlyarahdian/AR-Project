﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isTouched")]
public class IsTouched : Decide
{
    public override bool Decision(CharacterSO character)
    {
        return character.isTouched;
    }
}
