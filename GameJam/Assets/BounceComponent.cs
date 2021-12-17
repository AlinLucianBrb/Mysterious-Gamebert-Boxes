using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceComponent : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }
}
