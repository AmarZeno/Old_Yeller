using UnityEngine;
using System.Collections;
using CompleteProject;
using System.Collections.Generic;
public class NurseContact : MonoBehaviour {

    ArrayList totalPeople = new ArrayList();

   public List<GameObject> listOfFollowingPeople;

    void OnTriggerEnter(Collider other) {
        //if (other.tag == "Player") {

        //    totalPeople.AddRange(GameObject.FindGameObjectsWithTag("People"));


        //    foreach (GameObject person in totalPeople) {
        //        if (person.GetComponent<EnemyMovement>().inContact == true)
        //        {
        //            // Do nothing

        //        }
        //        else
        //        {
        //            totalPeople.Remove(person);
        //        }
        //    }

        //    for (int j = 0; j <= totalPeople.Count; j++)
        //    {
        //        (totalPeople[j] as GameObject).GetComponent<EnemyMovement>().inContact = false;
        //        (totalPeople[j] as GameObject).GetComponent<Movement>().enabled = true;
        //        totalPeople.RemoveAt(j);
        //    }
        //}

        if (other.tag == "Player") {
            
            totalPeople.AddRange(GameObject.FindGameObjectsWithTag("People"));

            foreach (GameObject person in totalPeople) {
                if (person.GetComponent<EnemyMovement>().inContact == true) {
                    if(!listOfFollowingPeople.Contains(person))
                        listOfFollowingPeople.Add(person);

                } else {
                   
                }
            }
            if (listOfFollowingPeople.Count > 0)
            {
                for (int j = 0; j <= (int)(listOfFollowingPeople.Count / 2); j++)
                {
                    (listOfFollowingPeople[j] as GameObject).GetComponent<EnemyMovement>().inContact = false;
                    (listOfFollowingPeople[j] as GameObject).GetComponent<Movement>().enabled = true;                   
                    listOfFollowingPeople.RemoveAt(j);
                }
                GameObject go = GameObject.FindWithTag("Player");
                go.GetComponentInParent<PlayerMovement>().UpdateScore();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
       // totalPeople = new ArrayList();
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
