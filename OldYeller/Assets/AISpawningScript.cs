using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpawningScript : MonoBehaviour {

    public List<GameObject> peopleSpawnPoints;
    public List<GameObject> nurseSpawnPoints;
    public GameObject People;
    public GameObject Nurse;

    List<int> usedValues = new List<int>();

    // Constants

    const int maxPeopleCount = 12;
    const int maxNurseCount = 3;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        TriggerPeople();
        TriggerNurses();
    }


    /* People spawn logic */
    void TriggerPeople() {
        GameObject[] peoples;
        peoples = GameObject.FindGameObjectsWithTag("People");

        if (peoples.Length >= maxPeopleCount)
        {
            // Prevent addition of new Peoples
        }
        else
        {
            InvokeRepeating("SpawnPeople", 0.2f, 5f);
        }
    }

    void SpawnPeople() {
        People = gameObject.GetComponent<ModelChange>().charactersToPopulate[Random.Range(0, gameObject.GetComponent<ModelChange>().charactersToPopulate.Count)];
        int SpawnPos = Random.Range(0, (peopleSpawnPoints.Count - 1));
        Instantiate(People, peopleSpawnPoints[SpawnPos].transform.position, transform.rotation);
        peopleSpawnPoints.RemoveAt(SpawnPos);
        CancelInvoke();
    }

    /* Nurse spawn logic */
    void TriggerNurses() {
        GameObject[] Nurses;
        Nurses = GameObject.FindGameObjectsWithTag("Nurse");

        if (Nurses.Length >= maxNurseCount)
        {
            // Prevent addition of new nurses
        }
        else
        {
            InvokeRepeating("SpawnNurse", 0.2f, 2f);
        }
    }

    void SpawnNurse() {
        int SpawnPos = Random.Range(0, (nurseSpawnPoints.Count - 1));
        Instantiate(Nurse, nurseSpawnPoints[SpawnPos].transform.position, transform.rotation);
        nurseSpawnPoints.RemoveAt(SpawnPos);
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
