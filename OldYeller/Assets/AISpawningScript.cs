using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpawningScript : MonoBehaviour {

    public List<GameObject> spawnPointsList;
    public GameObject Nurse;
    List<int> usedValues = new List<int>();

    // Constants
    const int maxNursesCount = 4;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Nurse");

        if (enemies.Length >= maxNursesCount)
        {
            // Prevent addition of new nurses
        }
        else {
            InvokeRepeating("SpawnEnemies", 1, 5f);
        }
	}

    void SpawnEnemies() {
        int SpawnPos = Random.Range(0, (spawnPointsList.Count - 1));
        Instantiate(Nurse, spawnPointsList[SpawnPos].transform.position, transform.rotation);
        spawnPointsList.RemoveAt(SpawnPos);
        CancelInvoke();
    }

    //public int UniqueRandomInt(int min, int max)
    //{
    //    int val = Random.Range(min, max);
    //    while (usedValues.Contains(val))
    //    {
    //        val = Random.Range(min, max);
    //    }
    //    usedValues.Add(val);
    //    return val;
    //}

}
