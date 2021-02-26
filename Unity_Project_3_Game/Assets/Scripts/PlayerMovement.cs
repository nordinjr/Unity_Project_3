using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float horizontal;

    public float runSpeed = 5f;
    public bool lookingright = true;
    public float jumpForce = 400f;

    private bool jumping;

    SpriteRenderer sr;
    Animator animator;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("horizontal", Math.Abs(horizontal));

        if (Input.GetKeyDown("space") && !jumping)
        {
            audio.Play();
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true; 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
        if (horizontal > 0 && !lookingright)
        {
            Flip();
        }
        else if (horizontal < 0 && lookingright)
        {
            Flip();
        }
    }

    private void Flip()
    {
        lookingright = !lookingright;

        transform.Rotate(0f, 180f, 0f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}
