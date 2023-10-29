using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    private Enemy[] _prefabs;
    private IFabric _fabric;
    private List<Enemy> _enemysPool = new List<Enemy>();

    public void Initialise(Enemy[] prefabs, int count)
    {
        _prefabs = prefabs;       

        for (int i = 0; i < count; i++)
        {
            Enemy spawned = Create(_prefabs[i % prefabs.Length]);
            spawned.gameObject.SetActive(false);
        }
    }

    public Enemy GetEnemy()
    {
       Enemy enemy = _enemysPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private Enemy Create(Enemy prefab)
    {
        Enemy enemy;

        if (prefab is Zombie)
            _fabric = new ZombieHealthFabric();     
        else if (prefab is Skeleton)
            _fabric = new SkeletonHealthFabric();
        else
            throw new ArgumentException("Нет соответствующего префаба", nameof(prefab));

        enemy = Instantiate(prefab, transform);
        enemy.Initialise(_fabric.Create());
        _enemysPool.Add(enemy);

        return enemy;
    }
}
