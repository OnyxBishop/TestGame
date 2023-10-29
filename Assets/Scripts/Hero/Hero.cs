using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Health _health;
    private Stamina _stamina;

    private AutoAttack _autoAttack;
    private MultishotAbility _multishot;
    private PowershotAbility _powershot;

    public Health Health => _health;
    public Stamina Stamina => _stamina;

    public void Initialise()
    {
        _health = new();
        _stamina = new();

        _autoAttack = GetComponentInChildren<AutoAttack>();
        _multishot = GetComponentInChildren<MultishotAbility>();
        _powershot = GetComponentInChildren<PowershotAbility>();

        _autoAttack.Initialise();
        _multishot.Initialise(_stamina);
        _powershot.Initialise(_stamina);
    }

    private void Update()
    {
        _stamina.Recharge();
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0f)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health.ApplyDamage(damage);
    }

    public void UseMultishot()
    {
        _multishot.Use();
    }

    public void UsePowershot()
    {
        _powershot.Use();
    }
}
