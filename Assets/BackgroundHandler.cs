using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour {

    public List<GameObject> spawnedInstances = new List<GameObject>();
    private int amountToExist = 3;
	
	// Update is called once per frame
	void Update () {
        if(spawnedInstances.Count > amountToExist) {
            GameObject toRemove = spawnedInstances[0];
            spawnedInstances.RemoveAt(0);
            Destroy(toRemove);
        }
	}
}
