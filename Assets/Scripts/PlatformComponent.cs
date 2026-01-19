using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    public Direction direction;
    Vector3 platformDirection;
    public float length = 2f;
    public float platformSpeed = 5f;
    public bool move;
    bool directionSwitch = true;
    Vector3 initialPos;
    Vector3 finalPos;
    Vector3 lastFramePos;
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
        if(move)
        {
            if (directionSwitch)
            {
                if (transform.position == finalPos)
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
        lastFramePos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(WaitAndMove(0.4f));
        collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

    IEnumerator WaitAndMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        move = true;
    }
}
