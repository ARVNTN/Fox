using UnityEngine;

public abstract class FoxBaseState
{
    public abstract void EnterState(FoxStateManager fox);
    public abstract void UpdateState(FoxStateManager fox);

    public static float sleepTimer = 10f;


    public void CheckStomach(FoxStateManager fox)
    {
        if (fox.stomach.status == 0)
        {
            fox.TransitionState(fox.dead);
        }

        else if (fox.stomach.status == 4)
        {
            fox.TransitionState(fox.sleeping);
        }
    }
}
