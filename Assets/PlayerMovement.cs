using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput; //for walk with addforce
    
    [SerializeField] float Speed;
    float move;

    [SerializeField] float JumpForce;
    [SerializeField] bool IsJumping;
    
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
        //walk with AddForce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);
        /*move = Input.GetAxis("Horizontal");

        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
        */

        
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
        }

    }

    private void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}   