﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SC : MonoBehaviour {

    public int speed = 5;
    public int jumpPower = 1250;
    private bool facingRight = false;
    private float moveX;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove ();
	}

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown ("Jump"))
        {
            Jump();
        }

        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
