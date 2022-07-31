public class FoxFollowingState : FoxBaseState
{

    public override void EnterState(FoxStateManager fox)
    {
    }

    public override void UpdateState(FoxStateManager fox)
    {
        CheckStomach(fox);
        if (fox.objectToFollow != null)
            fox.controller.MoveTowards(fox.objectToFollow.transform.position);
        else
        {
            fox.followObject = false;
            fox.TransitionState(fox.wandering);
        }
    }

}
