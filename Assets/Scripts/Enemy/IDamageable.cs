using System;

public interface IDamageable 
{
    public event Action Died;
    public void ApplyDamage(int damage);
    public void Reset();
}