using System.Collections;
using UnityEngine;

public class MultishotAbility : MonoBehaviour, IAbility
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Transform _arrowSpawnPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private ArrowsObjectPool _pool;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private const string HighAttack = nameof(HighAttack);

    private readonly float _arrowSpreadRadius = 5f;
    private readonly WaitForSeconds _delay = new(1f);

    private readonly int _arrowsCount = 10;
    private readonly int _staminaCost = 55;

    private Stamina _stamina;
    private Vector2 _direction;

    public void Initialise(Stamina stamina)
    {
        _pool.Initialise(_arrowPrefab, _arrowsCount);
        _stamina = stamina;
    }

    public void Use()
    {
        if (_stamina.IsEnough(_staminaCost))
            StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _animator.SetBool(HighAttack, true);
        yield return _delay;

        for (int i = 0; i < _arrowsCount; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * _arrowSpreadRadius;
            Vector2 spawnPoint = _arrowSpawnPoint.position + randomOffset;

            Arrow arrow = _pool.Get();

            SetArrow(arrow, spawnPoint);
        }

        _animator.SetBool(HighAttack, false);
    }

    private void SetArrow(Arrow arrow, Vector2 point)
    {
        _direction = new Vector2(1, -1);

        float rotationAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        arrow.Initialise(_damage, _speed);
        arrow.transform.position = point;
    }
}
