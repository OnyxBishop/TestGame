using UnityEngine;

public class SkeletonHealthFabric : IFabric
{
    public IDamageable Create()
    {
        return new DefaultEnemyHealth(new DefaultDyingPolicy());
    }
}
