using UnityEngine;

public class SpawnBootstrap : MonoBehaviour
{
    [SerializeField] private Spawn _heroSpawn;
    [SerializeField] private EnemySpawner _spawner;

    public void Initialise()
    {
        _heroSpawn.Initialise();
        _spawner.Initialise();
    }
}
