public class DefaultDyingPolicy : IDyingPolicy
{
    public bool Died(int health)
    {
        if (health == 0)
            return true;

        return false;
    }
}
