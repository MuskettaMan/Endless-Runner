using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour {

    [SerializeField] private BackgroundHandler bgHandler;
    [SerializeField] private GameObject backgroundPrefab;
    private float xOffset = 0;

    [SerializeField] private string name;


	// Use this for initialization
	void Start () {
        xOffset = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        SpawnBackground();
    }

    public void SpawnBackground() {
        GameObject instance = Instantiate(backgroundPrefab, transform.position + new Vector3(xOffset, 0, 0), transform.rotation);
        instance.name = name;
        bgHandler.spawnedInstances.Add(instance);
    }

}
