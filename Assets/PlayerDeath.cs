using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public bool died = false;

    private Animator animator;
    private PlayerController playerController;

    private void Start() {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Spike" && !died) {
            died = true;

            playerController.canMove = false;
            animator.SetBool("Die", true);
        }
    }
}
