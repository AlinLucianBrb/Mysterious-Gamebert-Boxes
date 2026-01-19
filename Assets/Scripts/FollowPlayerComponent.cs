using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerComponent : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = newPos;
    }
}
