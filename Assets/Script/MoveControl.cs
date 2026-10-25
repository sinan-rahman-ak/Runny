using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float jumbForce;
    public bool MoveLeft, MoveRight;
    public Animator animator;

    [Header("Ground Check Settings")]

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        MoveLeft = false;
        MoveRight = false;
        animator.SetTrigger("Idle");
    }

    void Update()
    {
        // Check if player is on ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        CheckKeyBordAction();

        if (MoveLeft)
        {
            float moveX = isGrounded ? -movespeed : -movespeed * 0.6f; // reduced air control
            rb.velocity = new Vector2(moveX, rb.velocity.y);
            animator.SetTrigger("Run");
        }
        else if (MoveRight)
        {
            float moveX = isGrounded ? movespeed : movespeed * 0.6f;
            rb.velocity = new Vector2(moveX, rb.velocity.y);
            animator.SetTrigger("Run");
        }
    }

    public void MoveLeftAction()
    {
        MoveLeft = true;
    }

    public void MoveRightAction()
    {
        MoveRight = true;
    }

    public void MoveJumbAction()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumbForce);
            animator.SetTrigger("Jump");
        }
    }

    public void MoveStop()
    {
        MoveLeft = false;
        MoveRight = false;
        rb.velocity = new Vector2(0, rb.velocity.y); // only stop horizontal movement
        animator.SetTrigger("Idle");
    }

    public void CheckKeyBordAction()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveStop();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStop();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveJumbAction();
        }
    }
}
