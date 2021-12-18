using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float health = 100f;

    void Update()
    {
        if(health <= 0)
        {
            //do smth
        }
    }

    public void AdjustHealth(float amount)
    {
        health += amount;
    }
}
