using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private float x;

    private Rigidbody2D rb_2d;

    private void Start() {
        rb_2d = GetComponent<Rigidbody2D>();
    }

    void Update () {

        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        rb_2d.velocity = new Vector2(x, 0);
	}
}
