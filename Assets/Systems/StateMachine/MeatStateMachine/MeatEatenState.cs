using System;
using UnityEngine;

public class MeatEatenState : MeatBaseState
{
    public override void Eat(GameObject fox, MeatStateManager meat)
    {
        
    }
    public override void EnterState(MeatStateManager meat)
    {
        meat.SpawnBones();
    }

    public override void UpdateState(MeatStateManager meat)
    {
        
    }

}
