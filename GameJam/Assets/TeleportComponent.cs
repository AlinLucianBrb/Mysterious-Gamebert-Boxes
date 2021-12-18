using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    public TeleportComponent teleport;
    bool teleported;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!teleported)
        {
            Vector3 relativePos = transform.InverseTransformPoint(collision.transform.position);
            collision.transform.position = teleport.transform.position + relativePos;
            teleport.teleported = true;
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        teleported = false;
    }
}
