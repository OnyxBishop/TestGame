using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transit> _transitions;

    protected Hero Target { get; set; }
    protected Movement Movement { get; set; }

    public void Enter(Hero target, Movement movement)
    {
        if (enabled == false)
        {
            Target = target;
            Movement = movement;
            enabled = true;

            foreach (Transit transition in _transitions)
            {
                transition.enabled = true;
                transition.Initialise(Target);
            }
        }
    }

    public State GetNext()
    {
        foreach (Transit transition in _transitions)
        {
            if (transition.IsNeedTransit == true)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (Transit transition in _transitions)
            {
                transition.enabled = false;

                enabled = false;
            }
        }
    }
}
