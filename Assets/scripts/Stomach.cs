using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stomach : MonoBehaviour
{
    public int status;
    private float timer;
    public float stomachTimer = 10f;

    private void ResetTimer()
    {
        timer = stomachTimer;
    }

    public void IncreaeStomachStatus()
    {
        status++;
        ResetTimer();
    }
    
    public void DecreaseStomachStatus()
    {
        status--;
        ResetTimer();
    }
    
    void Start()
    {
        status = Random.Range(1, 4);
        ResetTimer();
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ResetTimer();
            DecreaseStomachStatus();
        }
    }
}
