using System;
using UnityEngine;

public class Stamina 
{
    private float _max = 100f;
    private float _min = 0f;
    private float _rechargeSpeed = 2f;

    public Stamina() => CurrentValue = _max;

    public event Action<float> ValueChanged;
    public float CurrentValue { get; private set; }

    public void Recharge()
    {
        if (CurrentValue == _max)
            return;

        CurrentValue = Mathf.Clamp(CurrentValue + (_rechargeSpeed * Time.deltaTime), _min, _max);
        ValueChanged?.Invoke(CurrentValue);
    }

    public bool IsEnough(int abillityCost)
    {
        if (CurrentValue >= abillityCost)
        {
            CurrentValue -= abillityCost;
            return true;
        }

        return false;
    }
}
