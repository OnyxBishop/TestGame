using System.Collections;
using UnityEngine;

public class Zombie : Enemy
{
    private const string IsDead = nameof(IsDead);

    protected override void OnDied()
    {
        Die();
    }

    private void Die()
    {
        Movement.Stop();
        base.OnDied();
        Movement.StartWalk();
    }
}
