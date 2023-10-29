using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Hero target)
    {
        //_animator.Play("Attack");
        target.TakeDamage(_damage);
    }
}
