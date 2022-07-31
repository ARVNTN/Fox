using UnityEngine;

public class MeatInitialState : MeatBaseState
{
    private float _timer = 7f;
    
    public override void Eat(GameObject fox, MeatStateManager meat)
    {
        fox.GetComponent<Stomach>().IncreaeStomachStatus();
        meat.TransitionState(meat.eaten);
    }
    
    public override void EnterState(MeatStateManager meat)
    {
        _timer *= Random.Range(1, 3);
    }

    public override void UpdateState(MeatStateManager meat)
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
            meat.TransitionState(meat.rotten);
    }
}
