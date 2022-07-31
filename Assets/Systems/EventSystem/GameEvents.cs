using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action onDeath;

    public void Dying()
    {
        if (onDeath != null)
        {
            onDeath();
        }
    }

    public event Action onBadSpawn;

    public void Destroy()
    {
        if (onBadSpawn != null)
        {
            onBadSpawn();
        }
    }
}
