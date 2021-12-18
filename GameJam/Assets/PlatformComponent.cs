using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    public Direction direction;
    Vector3 platformDirection;
    public float length = 2f;
    public float platformSpeed = 5f;

    bool directionSwitch = true;
    Vector3 initialPos;
    Vector3 finalPos;
    
    void Start()
    {
        initialPos = transform.position;
        platformDirection = Vector2.zero;
        switch (direction)
        {
            case Direction.Up:
                platformDirection = Vector2.up;
                break;
            case Direction.Down:
                platformDirection = Vector2.down;
                break;
            case Direction.Left:
                platformDirection = Vector2.left;
                break;
            case Direction.Right:
                platformDirection = Vector2.right;
                break;
        }

        finalPos = transform.position + (platformDirection * length);
    }

    void Update()
    {
        if(directionSwitch)
        {
            if(transform.position == finalPos)
            {
                directionSwitch = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPos, platformSpeed * Time.deltaTime);
            }    
        }
        else
        {
            if (transform.position == initialPos)
            {
                directionSwitch = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, platformSpeed * Time.deltaTime);
            }
        }
    }
}
