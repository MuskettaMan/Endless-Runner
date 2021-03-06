﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 20;
    public float runSpeed = 40;
    public float slideSpeed = 30;
    public float jumpPower;
    public bool canMove = true;

    private float speed;
    [SerializeField] private bool isGrounded = true;
    private Rigidbody2D rb_2d;
    private Animator animator;
    public LayerMask groundLayer;

    private void Start() {
        rb_2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update () {

        if(!canMove)
            return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<SpriteRenderer>().bounds.size.y / 2 + .1f, groundLayer);

        isGrounded = (hit) ? true : false;

        if(Input.GetButtonDown("Jump") && isGrounded) {
            animator.SetTrigger("Jump");
            rb_2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        animator.SetBool("Falling", !isGrounded);

        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && isGrounded) {
            animator.SetBool("Running", true);
            speed = runSpeed;
        } else {
            animator.SetBool("Running", false);
            speed = walkSpeed;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && isGrounded) {
            animator.SetBool("Sliding", true);
            speed = slideSpeed;
        } else if(animator.GetBool("Sliding")){
            animator.SetBool("Sliding", false);
            speed = walkSpeed;
        }
    }

}
