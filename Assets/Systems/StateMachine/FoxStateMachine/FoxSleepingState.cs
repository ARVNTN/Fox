
using UnityEngine;

public class FoxSleepingState : FoxBaseState
{
    
    private float _timer;
    
    public override void EnterState(FoxStateManager fox)
    {
        fox.controller.SetWalking(false);
        fox.controller.SetSleeping(true);
        _timer = sleepTimer;
    }

    public override void UpdateState(FoxStateManager fox)
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            fox.TransitionState(fox.wandering);
        }
    }
}
