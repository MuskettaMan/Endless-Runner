using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private List<GameObject> obstacleList = new List<GameObject>();

    [SerializeField] private List<GameObject> spawnedObstacles = new List<GameObject>();

    private PlayerTracker playerTracker;

    public float bufferLength = 1;

	// Use this for initialization
	void Start () {
        playerTracker = GetComponent<PlayerTracker>();

        spawnObstacle();
	}
	
	// Update is called once per frame
	void Update () {

        if(spawnedObstacles[spawnedObstacles.Count - 1].GetComponent<ObstacleHandler>().playerInObstacle) {
            spawnObstacle();

            Debug.Log(spawnedObstacles.Count);

            if(spawnedObstacles.Count > 4) {
                GameObject toRemove = spawnedObstacles[0];
                spawnedObstacles.RemoveAt(0);

                Destroy(toRemove);
            }
        }
		
	}

    private void spawnObstacle() {

        Vector3 position = transform.position;
        int indexNumber = generateRandomIndexNumber(obstacleList.Count);

        playerTracker.SetOffset(new Vector3(-obstacleList[indexNumber].GetComponent<ObstacleHandler>().GetObstacleLength() - bufferLength, 0, -1f));

        position = transform.position;
        GameObject obstacle = Instantiate(obstacleList[indexNumber], position, transform.rotation);

        spawnedObstacles.Add(obstacle);

    }

    private int generateRandomIndexNumber(int max) {
        return Mathf.FloorToInt(Random.Range(0, max));
    }

}
