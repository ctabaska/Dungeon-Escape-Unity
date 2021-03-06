using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 100;

    public CharacterController2D controller;

    public Animator animator;

    float horizontalMove = 0f;

    bool jump = false;

    public Rigidbody2D body;

    public bool allowMovement = true;


    // Start is called before the first frame update
    void Start()
    {
          
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
        animator.SetFloat("yVelocity", body.velocity.y);

        if (body.velocity.y <= -0.01f)
        {
            body.gravityScale = 5f;
        }
        else
        {
            body.gravityScale = 2.5f;
        }
        if ( allowMovement && Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (allowMovement)
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;


    }
}
