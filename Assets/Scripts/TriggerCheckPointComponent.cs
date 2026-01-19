using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckPointComponent : MonoBehaviour
{
    public int checkPointPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CheckPointComponent>().checkPointReached[checkPointPos] = true;
    }
}
