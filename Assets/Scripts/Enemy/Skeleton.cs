using System.Collections;
using UnityEngine;

public class Skeleton : Enemy
{
    private int _deathCount = 0;
    private const string IsDead = nameof(IsDead);
    private const string Respawning = nameof(Respawning);

    private WaitForSeconds _wait = new (1f); 

    protected override void OnDied()
    {       
        if (_deathCount == 1)
        {           
            _deathCount = 0;
            base.OnDied();
        }

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        Movement.Stop();
        _deathCount++;

        Animator.SetBool(IsDead, true);
        yield return _wait;

        Animator.SetBool(IsDead, false);
        Animator.SetBool(Respawning, true);
        Health.Reset();

        yield return _wait;
        Animator.SetBool(Respawning,false);
        Movement.StartWalk();
    }
}
