using UnityEngine;

public class FoxWanderingState : FoxBaseState
{
    public override void EnterState(FoxStateManager fox)
    {
        fox.controller.SetSleeping(false);
        fox.controller.Wander();
    }

    public override void UpdateState(FoxStateManager fox)
    {
        CheckStomach(fox);
        if (fox.followObject)
        {
            fox.TransitionState(fox.following);
        }
        else
        {
            fox.controller.Wander();
        }
    }
}
