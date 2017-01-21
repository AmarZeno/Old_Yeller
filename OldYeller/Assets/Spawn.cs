using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] enemies;
    public int amount;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;

        if (amount != 10) {
            InvokeRepeating("spawnEnemy", 1, 5f);
        }
	}

    void spawnEnemy() {
        spawnPoint.x = Random.Range(-20, 20);
        spawnPoint.y = 0.5f;
        spawnPoint.z = Random.Range(-20, 20);

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
}
