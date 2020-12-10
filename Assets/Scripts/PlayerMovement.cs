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
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //MOVERSE, IZQUIERDA Y DERECHA
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
        //ESTADO QUIETO
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            animator.SetBool("moving", false);
        }
        //VERIFICAR SI ESTÁ EN EL SUELO PARA SALTAR
        if (Input.GetKeyDown("w") && CheckGround.isGrounded || Input.GetKeyDown("space") && CheckGround.isGrounded)
        {
            rigidBody.AddForce(new Vector2(0, jumpSpeed));
        }
        //NO MOVERSE SI SE MUEVE HACIA AMBOS LADOS
        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            animator.SetBool("moving", false);
        }
        
        
        //AGACHARSE
        
        if (Input.GetKey("s"))
        {
            animator.SetBool("bend", true);
        }

        if (!Input.GetKey("s"))
        {
            animator.SetBool("bend", false);
        }

        if ((Input.GetKey("s")) && Input.GetKey("a") || (Input.GetKey("s")) && Input.GetKey("d"))
        {
            animator.SetBool("move_bend", true);
        }
        
        if (!((Input.GetKey("s")) && Input.GetKey("a") || (Input.GetKey("s")) && Input.GetKey("d")))
        {
            animator.SetBool("move_bend", false);
        }
        
        
        
    }
}
