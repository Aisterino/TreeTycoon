using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask canJumpOnMask;
    public float movementInput = 0f;
    private float speed = 4f;
    private float jumpSpeed = 5f;
    private Rigidbody2D rb;
    private Collider2D collider;
    private bool canJump;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {   
        if (movementInput != 0)
        {
            //animator.SetBool("Walking", true);
            if (movementInput < 0)
            {
                transform.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

        }
        else
        {
            //animator.SetBool("Walking", false);
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= collider.bounds.extents.x;
        topLeftPoint.y += collider.bounds.extents.y;

        Vector2 bottomRight = transform.position;
        bottomRight.x += collider.bounds.extents.x;
        bottomRight.y -= (collider.bounds.extents.y + .1f);

        Debug.DrawLine(topLeftPoint, bottomRight);

        if (Physics2D.OverlapArea(topLeftPoint, bottomRight, canJumpOnMask))
        {
            canJump = true;
        }
    }

    public void MoveInput(float input)
    {
        movementInput += input;
    }

    public void Jump(float jumpSpeed, bool forcedJump)
    {
        if(!forcedJump)
        {
            jumpSpeed = this.jumpSpeed;
        }

        if (canJump || forcedJump)
        {
            canJump = false;
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            //animator.SetTrigger("Jump");
        }
    }
}
