using System;
using UnityEngine;

public class DefaultEnemyHealth : IDamageable
{
    private const int Max = 100;
    private const int Min = 0;

    private int _value;
    private IDyingPolicy _dyingPolicy;

    public DefaultEnemyHealth(IDyingPolicy dyingPolicy)
    {
        _value = Max;
        _dyingPolicy = dyingPolicy;
    }

    public event Action Died;

    public void ApplyDamage(int damage)
    {
        _value = Mathf.Clamp(_value - damage, Min, Max);

        if (_dyingPolicy.Died(_value) == true)
            Died?.Invoke();
    }

    public void Reset()
    {
        _value = Max;
    }
}
