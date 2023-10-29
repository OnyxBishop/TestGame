using System;
using UnityEngine;

public class Health 
{
    private int _max = 100;
    private int _min = 0;

    public Health() => CurrentValue = _max;

    public int CurrentValue { get; private set; }

    public event Action<int> Changed;
    public event Action Died;

    public void ApplyDamage(int damage)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - damage, _min, _max);

        Changed?.Invoke(CurrentValue);

        if (CurrentValue == _min)
            Died?.Invoke();
    }
}
