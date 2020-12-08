using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 2;

    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody.velocity = new Vector2(-runSpeed, rigidBody.velocity.y);
        }
        else{
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if(rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }
        if(rigidBody.velocity.y > 0 && !Input.GetKey("space"))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }
    }
}
