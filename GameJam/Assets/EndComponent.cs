using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndComponent : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Animator animator;
    public PlayerController playerController;

    public AudioSource a1;
    public AudioSource a2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = sprite;
        playerController.enabled = false;
        animator.SetTrigger("RickRollStart");

        a1.Stop();
        a2.Play();
    }
}
