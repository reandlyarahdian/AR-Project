using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Act/ToGate")]
public class ToGate : Act
{
    private Side side;
    public override void Action(CharacterSO character)
    {
        side = character.side;
        character.Move(character.gate(GateCheck(side)).transform.position, 0.75f);
    }

    private string GateCheck(Side side)
    {
        switch (side)
        {
            case Side.Attack:
                return "Defender";
            case Side.Defend:
                return "Attacker";
            default: 
                return null;
        }
    }
}
