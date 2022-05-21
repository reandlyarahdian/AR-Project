using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class StateSO : ScriptableObject
{
    public Act[] acts;
    public Transition[] transitions;

    public void UpdateState(CharacterSO movement)
    {
        DoAction(movement);
        CheckTransition(movement);
    }
    public void DoAction(CharacterSO movement)
    {
        foreach (Act act in acts)
        {
            act.Action(movement);
        }
    }
    public void CheckTransition(CharacterSO movement)
    {
        foreach (Transition transition in transitions)
        {
            bool decided = transition.decide.Decision(movement);
            if (decided)
            {
                movement.TransitionToState(transition.trueS);
            }
            else
            {
                movement.TransitionToState(transition.falseS);
            }
        }
    }
}

[System.Serializable]
public class Transition
{
    public Decide decide;
    public StateSO trueS;
    public StateSO falseS;
}
