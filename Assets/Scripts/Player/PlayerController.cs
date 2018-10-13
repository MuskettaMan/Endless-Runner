using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 20;
    public float runSpeed = 40;
    public float jumpPower;

    private float speed;
    private Rigidbody2D rb_2d;
    private Animator animator;

    private void Start() {
        rb_2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update () {

        if(Input.GetButtonDown("Jump")) {
            rb_2d.AddForce(new Vector2(0, jumpPower * Time.deltaTime), ForceMode2D.Impulse);
        }

        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            animator.SetBool("Running", true);
            speed = runSpeed;
        } else {
            animator.SetBool("Running", false);
            speed = walkSpeed;
        }
	}
}
