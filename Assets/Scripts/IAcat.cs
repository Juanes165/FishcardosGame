﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAcat : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform[] moveSpots;
    private Vector2 currentPos;

    public float speed = 3f;
    private float waitTime;
    public float startWaitTime = 2;
    private int i = 0;
    
    void Start()
    {
        waitTime = startWaitTime;    
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(CheckEnemyMovement());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                if(moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMovement()
    {
        currentPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if(transform.position.x > currentPos.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < currentPos.x)
        {
            spriteRenderer.flipX = true;
        }

    }
}
