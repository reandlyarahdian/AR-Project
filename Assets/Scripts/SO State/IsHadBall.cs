using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isHadBall")]
public class IsHadBall : Decide
{
    private bool ball;
    public override bool Decision(CharacterSO character)
    {
        ball = character.ballHolder.GetComponent<FrontTrigger>().isBall || character.CheckCountDown(2);
        return ball;
    }
}
