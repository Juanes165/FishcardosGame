using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 250f;
    public float jumpSpeed = 200f;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    Rigidbody2D rigidBody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canJump = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            animator.SetBool("moving", true);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(new Vector2(speed * Time.deltaTime, 0));
            animator.SetBool("moving", true);
            spriteRenderer.flipX = false;
        }

        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKeyDown("w") && CheckGround.isGrounded)
        {
            //canJump = false;
            rigidBody.AddForce(new Vector2(0, jumpSpeed));
        }
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            canJump = true;
        }
    }
    */
}
