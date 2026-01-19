using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    bool grounded;
    bool movingLeft = true;
    bool holeAhead;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(movingLeft && grounded && !holeAhead && Mathf.Abs(rigidbody2D.linearVelocity.x) <= 2.5f)
        {
            rigidbody2D.AddForce(Vector2.left * 2);
        }

        if(!movingLeft && grounded && !holeAhead && Mathf.Abs(rigidbody2D.linearVelocity.x) <= 2.5f)
        {
            rigidbody2D.AddForce(Vector2.right * 2);
        }

        if(holeAhead)
        {
            movingLeft = movingLeft ? false : true;
            rigidbody2D.linearVelocity = new Vector2(0, rigidbody2D.linearVelocity.y);
            holeAhead = false;
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
        CheckIfHoleAhead();
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

    private void CheckIfHoleAhead()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        Vector2 direction = movingLeft ? new Vector2(-0.5f, -1) : new Vector2(0.5f, -1);
        hits = Physics2D.RaycastAll(positionToCheck, direction, 1f);

        if (hits.Length == 1)
        {
            holeAhead = true;
        }
    }
}
