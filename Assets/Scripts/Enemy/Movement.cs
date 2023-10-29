using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed;
    private float _maxSpeed = 2f;

    public void MoveTo(Transform point)
    {
        Vector2 targetVelocity = ((Vector2)point.position - (Vector2)transform.position).normalized;
        Vector2 movement = _speed * Time.deltaTime * targetVelocity;
        transform.Translate(movement);
    }

    public void Stop()
    {
        _speed = 0;
    }

    public void StartWalk()
    {
        _speed = _maxSpeed;
    }
}
