using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float jump = 5;
    public float speed = 5;

    bool grounded;
    bool wallLeft;
    bool wallRight;

    bool isGoingLeft;
    bool isGoingRight;
    bool isJumping;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGoingLeft = Input.GetKey(KeyCode.A) ? true : false;
        isGoingRight = Input.GetKey(KeyCode.D) ? true : false;
        isJumping = Input.GetKeyDown(KeyCode.Space) ? true : false;

        if (isGoingLeft && rigidbody2D.velocity.x >= -5 && !wallLeft)
        {
            rigidbody2D.AddForce(Vector2.left * 2);
        }

        if (isGoingRight && rigidbody2D.velocity.x <= 5 && !wallRight)
        {
            rigidbody2D.AddForce(Vector2.right * 2);
        }

        if (isJumping && grounded && !wallLeft && !wallRight)
        {
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
        CheckIfWallLeft();
        CheckIfWallRight();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        grounded = false;
        wallLeft = false;
        wallRight = false;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        if (hits.Length > 0)
        {
            grounded = true;
        }
    }

    private void CheckIfWallLeft()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(-1, 0), 0.26f);

        if (hits.Length > 1)
        {
            wallLeft = true;
        }
        else
        {
            wallLeft = false;
        }
    }

    private void CheckIfWallRight()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(1, 0), 0.26f);

        if (hits.Length > 1)
        {
            wallRight = true;
        }
        else
        {
            wallRight = false;
        }
    }
}
