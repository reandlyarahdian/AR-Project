﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decide : ScriptableObject
{
    public abstract bool Decision(CharacterSO character);
}
