using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decide/isInactive")]
public class isInactive : Decide
{
    private Side side;
    public override bool Decision(CharacterSO character)
    {
        bool isDone = character.CheckCountDown(Sides(character));
        return isDone;
    }
    
    private float Sides(CharacterSO character)
    {
        side = character.side;
        if (side == Side.Attack)
        {
            return 2.5f;
        }
        else if (side == Side.Defend)
        {
            return 4f;
        }
        return 0f;
    }
}
