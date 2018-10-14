using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour {

    [SerializeField] private float obstacleLength;

    public bool playerInObstacle;

    private void Start() {
        playerInObstacle = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            playerInObstacle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            playerInObstacle = false;
        }
    }

    public float GetObstacleLength() {
        return obstacleLength;
    }

}
