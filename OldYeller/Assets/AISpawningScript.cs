using UnityEngine;
using System.Collections;

public class AISpawningScript : MonoBehaviour {

    public GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnLocation");
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length >= 4)
        {
            // Too many
        }
        else {
            InvokeRepeating("spawnEnemies", 1, 5f);
        }
	}

    void spawnEnemies() {
        int SpawnPos = Random.Range(0, (spawnPoints.Length - 1));
    }
}
