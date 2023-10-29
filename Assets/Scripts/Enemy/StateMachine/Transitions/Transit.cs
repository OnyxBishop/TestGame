using UnityEngine;

public abstract class Transit : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Hero Target { get; private set; }

    public State TargetState => _targetState;
    public bool IsNeedTransit { get; protected set; }

    public void Initialise(Hero target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        IsNeedTransit = false;
    }
}
