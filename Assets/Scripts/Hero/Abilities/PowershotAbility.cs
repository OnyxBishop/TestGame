using System.Collections;
using UnityEngine;

public class PowershotAbility : MonoBehaviour, IAbility
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private const string LowAttack = nameof(LowAttack);
    private WaitForSeconds _delay = new (1f);

    private int _staminaCost = 30;
    private Stamina _stamina;

    public void Initialise(Stamina stamina)
    {
        _stamina = stamina;
    }

    public void Use()
    {
        if (_stamina.IsEnough(_staminaCost))
            StartCoroutine(Shoot());                 
    }

    private IEnumerator Shoot()
    {
        _animator.SetBool(LowAttack, true);
        yield return _delay;

        Arrow arrow = Instantiate(_arrowPrefab);
        arrow.Initialise(_damage, _speed);
        arrow.transform.position = _spawnPoint.position;

        _animator.SetBool(LowAttack, false);
    }
}
