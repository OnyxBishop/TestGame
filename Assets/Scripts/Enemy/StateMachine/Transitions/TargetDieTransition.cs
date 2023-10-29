public class TargetDieTransition : Transit
{
    private void Update()
    {
        if (Target == null)
            IsNeedTransit = true;
    }
}
