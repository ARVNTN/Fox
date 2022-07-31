using System;

public class FoxDeadState : FoxBaseState
{
    public override void EnterState(FoxStateManager fox)
    {
        try
        {
            fox.SpawnBones(fox.transform.position);
        }
        catch (Exception)
        {
        }
    }

    public override void UpdateState(FoxStateManager fox)
    {
        fox.Destroy();
    }
}
