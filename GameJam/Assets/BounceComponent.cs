using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class BounceComponent : MonoBehaviour
{
    public Direction direction;
    public float bouncePower = 5f;

    Vector2 bounceDirection;

    void Start()
    {
        bounceDirection = Vector2.zero;
        switch (direction)
        {
            case Direction.Up:
                bounceDirection = Vector2.up;
                break;
            case Direction.Down:
                bounceDirection = Vector2.down;
                break;
            case Direction.Left:
                bounceDirection = Vector2.left;
                break;
            case Direction.Right:
                bounceDirection = Vector2.right;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * bouncePower, ForceMode2D.Impulse);
        collider.gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");
    }
}
