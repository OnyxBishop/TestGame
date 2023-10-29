using System;
using UnityEngine;

public class EnemySpawner : EnemyObjectPool
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private int _count;
    [SerializeField] private Transform _spawnPoint;

    private Enemy _enemy;

    private float _spawnTime = 2f;
    private float _elapsedTime;

    private int _spawnedCount = 0;
    private int _deadUnitsCount = 0;
    private int _maxUnits = 15;

    public void Initialise()
    {
        Initialise(_enemyPrefabs,_count);
    }

    public event Action AllEnemyDied;

    private void Update()
    {
        if (_spawnedCount >= _maxUnits)
            return;

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnTime)
        {
            _elapsedTime = 0;

            _enemy = GetEnemy();
            _enemy.Dying += OnDying;
            
            SetEnemy(_enemy,_spawnPoint.position);
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        _spawnedCount++;
    }

    private void OnDying(Enemy enemy)
    {
        ReturnToPool(enemy);
        _deadUnitsCount++;

        if (_deadUnitsCount >= _maxUnits)
            AllEnemyDied?.Invoke();
    }
}
