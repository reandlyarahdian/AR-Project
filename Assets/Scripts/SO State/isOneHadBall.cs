using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isOneHadBall")]
public class isOneHadBall : Decide
{
    public override bool Decision(CharacterSO character)
    {
        return Ball.ball;
    }
}
