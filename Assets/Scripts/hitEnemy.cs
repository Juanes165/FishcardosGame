using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class hitEnemy : MonoBehaviour
{
    public Collider2D collider;
    public SpriteRenderer spriteRenderer;
    public AudioSource clip;

    public float jumpForce = 150f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            spriteRenderer.enabled = false;
            Invoke("die", 0.1f);

            clip.Play();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

}
