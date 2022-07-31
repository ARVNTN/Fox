using UnityEngine;

public abstract class MeatBaseState
{
   public abstract void EnterState(MeatStateManager meat);
   public abstract void UpdateState(MeatStateManager meat);

   public abstract void Eat(GameObject fox,MeatStateManager meat);
}