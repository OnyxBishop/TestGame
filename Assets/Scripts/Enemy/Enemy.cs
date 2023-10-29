using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public abstract class Enemy : MonoBehaviour
{
    protected IDamageable Health;
    protected Animator Animator;
    protected Movement Movement;

    private Hero _target;

    public void Initialise(IDamageable health)
    {
        Animator = GetComponentInChildren<Animator>();
        Movement = GetComponent<Movement>();
        Health = health;
        _target = FindFirstObjectByType<Hero>();

        health.Died += OnDied;
    }

    public event Action<Enemy> Dying;

    public Hero GetTarget => _target;
    public Movement GetMovement => Movement;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Health.ApplyDamage(damage);
    }

    protected virtual void OnDied()
    {
        StartCoroutine(InvokeDying());       
    }     

    private IEnumerator InvokeDying()
    {
        Animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(1f);
        Animator.SetBool("IsDead", false);
        Dying?.Invoke(this);
    }
}