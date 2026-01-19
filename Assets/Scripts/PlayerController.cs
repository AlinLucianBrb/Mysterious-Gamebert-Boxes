using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Collider2D collider2D;
    AudioSource audioSource;

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
        collider2D = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGoingLeft = Input.GetKey(KeyCode.A);
        isGoingRight = Input.GetKey(KeyCode.D);
        isJumping = Input.GetKeyDown(KeyCode.Space);

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Velocity", Mathf.Abs(rigidbody2D.linearVelocity.x));
    }

    void FixedUpdate()
    {
        CheckIfGrounded();
        CheckIfWallLeft();
        CheckIfWallRight();

        if (isGoingLeft && rigidbody2D.linearVelocity.x >= -speed && !wallLeft)
        {
            rigidbody2D.AddForce(Vector2.left * speed);
            spriteRenderer.flipX = true;
        }

        if (isGoingRight && rigidbody2D.linearVelocity.x <= speed && !wallRight)
        {
            rigidbody2D.AddForce(Vector2.right * speed);
            spriteRenderer.flipX = false;
        }

        if (isJumping && grounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            if (audioSource != null) audioSource.Play();
        }
    }

    private void CheckIfGrounded()
    {
        Bounds b = collider2D.bounds;
        Vector2 origin = new Vector2(b.center.x, b.min.y + 0.01f);
        float distance = 0.08f;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, layerMask);
        grounded = hit.collider != null && hit.collider != collider2D;
    }

    private void CheckIfWallLeft()
    {
        Bounds b = collider2D.bounds;
        float distance = 0.08f;

        Vector2 mid = new Vector2(b.min.x + 0.01f, b.center.y);
        Vector2 top = new Vector2(b.min.x + 0.01f, b.max.y - 0.01f);
        Vector2 bot = new Vector2(b.min.x + 0.01f, b.min.y + 0.01f);

        RaycastHit2D hitMid = Physics2D.Raycast(mid, Vector2.left, distance, layerMask);
        RaycastHit2D hitTop = Physics2D.Raycast(top, Vector2.left, distance, layerMask);
        RaycastHit2D hitBot = Physics2D.Raycast(bot, Vector2.left, distance, layerMask);

        wallLeft =
            (hitMid.collider != null && hitMid.collider != collider2D) ||
            (hitTop.collider != null && hitTop.collider != collider2D) ||
            (hitBot.collider != null && hitBot.collider != collider2D);
    }

    private void CheckIfWallRight()
    {
        Bounds b = collider2D.bounds;
        float distance = 0.08f;

        Vector2 mid = new Vector2(b.max.x - 0.01f, b.center.y);
        Vector2 top = new Vector2(b.max.x - 0.01f, b.max.y - 0.01f);
        Vector2 bot = new Vector2(b.max.x - 0.01f, b.min.y + 0.01f);

        RaycastHit2D hitMid = Physics2D.Raycast(mid, Vector2.right, distance, layerMask);
        RaycastHit2D hitTop = Physics2D.Raycast(top, Vector2.right, distance, layerMask);
        RaycastHit2D hitBot = Physics2D.Raycast(bot, Vector2.right, distance, layerMask);

        wallRight =
            (hitMid.collider != null && hitMid.collider != collider2D) ||
            (hitTop.collider != null && hitTop.collider != collider2D) ||
            (hitBot.collider != null && hitBot.collider != collider2D);
    }
}
