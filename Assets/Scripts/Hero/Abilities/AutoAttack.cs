using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [Header("Components Ref")]
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Transform _arrowSpawnPoint;
    [SerializeField] private ArrowsObjectPool _pool;

    [Header("Arrow stats")]
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public void Initialise()
    {
        _pool.Initialise(_arrowPrefab);
    }

    public void Attack()
    {
        Arrow arrow = _pool.Get();

        SetArrow(arrow, _arrowSpawnPoint.position);
    }

    private void SetArrow(Arrow arrow, Vector2 point)
    {
        arrow.Initialise(_damage, _speed);
        arrow.transform.position = point;
    }
}
