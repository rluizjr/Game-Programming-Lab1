using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public string horizontal;
    public string jump;

    public float maxSpeed = 5;
    public Transform groundCheck;
    public LayerMask defineGround;
    public float jumpForce = 5;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float groundCheckRadius = 0.3f;
    private bool isGrounded = false;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis(jump) > 0 && isGrounded)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, defineGround);
        animator.SetBool("Ground", isGrounded);
        Debug.Log(isGrounded);

        animator.SetFloat("vSpeed", rBody.velocity.y);

        float moveHoriz = Input.GetAxis(horizontal);
        animator.SetFloat("Speed", Math.Abs(moveHoriz));

        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);

        if (moveHoriz > 0)
        {
            sRend.flipX = false;
        }
        else if (moveHoriz < 0)
        {
            sRend.flipX = true;
        }
    }
}
