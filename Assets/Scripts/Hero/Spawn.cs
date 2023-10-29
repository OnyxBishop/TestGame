using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Hero _prefab;
    [SerializeField] private Transform _spawnPoint;

    private const string IsDead = nameof(IsDead);

    private static Hero _spawned;
    private Animator _heroAnimator;

    public void Initialise()
    {
        _spawned = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        _spawned.Initialise();
        _heroAnimator = _spawned.GetComponentInChildren<Animator>();
        _spawned.Health.Died += OnDied;
    }

    public static Hero HeroInstance => _spawned;

    private void OnDied()
    {
        _spawned.Health.Died -= OnDied;
        _heroAnimator.SetBool(IsDead, true);
    }
}
