using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float jump = 5;
    public float speed = 5;

    public LayerMask layerMask;

    bool grounded;
    bool wallLeft;
    bool wallRight;

    bool isGoingLeft;
    bool isGoingRight;
    bool isJumping;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGoingLeft = Input.GetKey(KeyCode.A) ? true : false;
        isGoingRight = Input.GetKey(KeyCode.D) ? true : false;
        isJumping = Input.GetKeyDown(KeyCode.Space) ? true : false;
 
        animator.SetFloat("Velocity", 0);
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Velocity", rigidbody2D.velocity.x);

        if (isGoingLeft && rigidbody2D.velocity.x >= -5 && !wallLeft)
        {
            rigidbody2D.AddForce(Vector2.left * 2);
            spriteRenderer.flipX = true;
        }

        if (isGoingRight && rigidbody2D.velocity.x <= 5 && !wallRight)
        {
            rigidbody2D.AddForce(Vector2.right * 2);
            spriteRenderer.flipX = false;
        }

        if (isJumping && grounded && !wallLeft && !wallRight)
        {
            rigidbody2D.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        Debug.Log(wallLeft);
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
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 5f);

        if (hits.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void CheckIfWallLeft()
    {
        RaycastHit2D[] hits;

        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(-1, 0), 0.26f, layerMask);
        if (hits.Length > 0)
        {
            wallLeft = true;
            return;
        }
        else
        {
            wallLeft = false;
        }

        positionToCheck = transform.position + new Vector3(0,GetComponent<Collider2D>().bounds.extents.y,0);
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(-1, 0), 0.26f, layerMask);

        if (hits.Length > 0)
        {
            wallLeft = true;
            return;
        }
        else
        {
            wallLeft = false;
        }

        positionToCheck = transform.position - new Vector3(0, GetComponent<Collider2D>().bounds.extents.y, 0);
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(-1, 0), 0.26f, layerMask);

        if (hits.Length > 0)
        {
            wallLeft = true;
            return;
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
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(1, 0), 0.26f, layerMask);

        if (hits.Length > 0)
        {
            wallRight = true;
            return;
        }
        else
        {
            wallRight = false;
        }

        positionToCheck = transform.position + new Vector3(0, GetComponent<Collider2D>().bounds.extents.y, 0);
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(1, 0), 0.26f, layerMask);
        if (hits.Length > 0)
        {
            wallRight = true;
            return;
        }
        else
        {
            wallRight = false;
        }

        positionToCheck = transform.position - new Vector3(0, GetComponent<Collider2D>().bounds.extents.y, 0);
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(1, 0), 0.26f, layerMask);
        if (hits.Length > 0)
        {
            wallRight = true;
            return;
        }
        else
        {
            wallRight = false;
        }
    }
}
