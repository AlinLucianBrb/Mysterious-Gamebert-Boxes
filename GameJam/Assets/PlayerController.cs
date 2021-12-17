using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float distToGround;
    public float jump = 5;
    public float speed = 5;

    bool grounded;

    bool isGoingLeft;
    bool isGoingRight;
    bool isJumping;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        Debug.Log(distToGround);
    }

    void Update()
    {
        isGoingLeft = Input.GetKey(KeyCode.A) ? true : false;
        isGoingRight = Input.GetKey(KeyCode.D) ? true : false;
        isJumping = Input.GetKeyDown(KeyCode.Space) ? true : false;

        if (isGoingLeft)
        {
            rigidbody2D.AddForce(Vector2.left * 2);
        }

        if (isGoingRight)
        {
            rigidbody2D.AddForce(Vector2.right * 2);
        }

        if (isJumping && grounded)
        {
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        grounded = false;
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
}
