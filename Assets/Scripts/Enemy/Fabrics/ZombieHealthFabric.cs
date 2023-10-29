using UnityEngine;

public class ZombieHealthFabric : IFabric
{
    public IDamageable Create()
    {
        return new DefaultEnemyHealth(new DefaultDyingPolicy());
    }
}
