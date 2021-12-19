using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointComponent : MonoBehaviour
{
    public Transform[] checkpointSpawns;
    public bool[] checkPointReached;

    void Start()
    {
        checkPointReached = new bool[6];    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            for (int i = checkPointReached.Length - 1; i >= 0; i--)
            {
                if(checkPointReached[i])
                {
                    transform.position = checkpointSpawns[i].position;
                    return;
                }
            }
        }
    }
}
