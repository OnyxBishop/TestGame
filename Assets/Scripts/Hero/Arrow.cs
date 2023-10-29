using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float _forceMultiplier;

    private int _damage;

    private Vector2 _initialVelocity;

    private Rigidbody2D _rigidbody;

    public void Initialise(int damage, float speed)
    {
        _damage = damage;
        _initialVelocity = transform.right * speed;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public event Action<Arrow> Hitted;

    private void FixedUpdate()
    {
        Vector2 force = (_initialVelocity - _rigidbody.velocity) * _rigidbody.mass / Time.fixedDeltaTime;
        force += Physics2D.gravity * _rigidbody.mass;
        _rigidbody.AddForce(force * _forceMultiplier);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Hitted?.Invoke(this);
        }
        else if (collision.TryGetComponent<Ground>(out _))
        {
            Hitted?.Invoke(this);
        }
    }
}
