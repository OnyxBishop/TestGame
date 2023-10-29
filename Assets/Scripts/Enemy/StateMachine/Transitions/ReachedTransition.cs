using UnityEngine;

public class ReachedTransition : Transit
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - transform.position.x) < _transitionRange)
            IsNeedTransit = true;
    }
}
