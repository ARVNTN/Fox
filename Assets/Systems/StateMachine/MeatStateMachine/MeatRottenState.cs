using UnityEngine;

public class MeatRottenState : MeatBaseState
{
    public override void Eat(GameObject fox, MeatStateManager meat)
    {
        fox.GetComponent<Stomach>().DecreaseStomachStatus();
        meat.TransitionState(meat.eaten);
    }
    public override void EnterState(MeatStateManager meat)
    {
        Debug.Log("meat is rotting!");
    }

    public override void UpdateState(MeatStateManager meat)
    {
        
    }
}
