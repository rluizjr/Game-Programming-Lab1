using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public float runSpeed = 5.0f;
    public float jumpSpeed = 400.0f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    public float timeInvert = 5f;
    public float distance = 5f;

    private bool goingLeft = true;
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator anim;
    private bool isGrounded;
    private float moveHorizontal;

    private void invert()
    {
        goingLeft = !goingLeft;
        moveHorizontal = goingLeft ? -distance : distance;
        Invoke("invert", timeInvert);
    }


    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        invert();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("Grounded", isGrounded);

        anim.SetFloat("vSpeed", rBody.velocity.y);

        if (isGrounded)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            rBody.velocity = new Vector2(moveHorizontal * runSpeed, rBody.velocity.y);

            if (rBody.velocity.x > 0.0f)
                sRend.flipX = false;
            else if (rBody.velocity.x < 0.0f)
                sRend.flipX = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
