using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CompleteProject;

public class ModelChange : MonoBehaviour {

   public GameObject[] listOfCharacters;
    public GameObject[] modelPrefabs;
   public List<GameObject> charactersToPopulate;
   int selectedCharacterIndex = -1;

	// Use this for initialization
	void Start () {
        //selectedCharacterIndex = PlayerPrefs.GetInt("characters");
        selectedCharacterIndex = 1;
        if (selectedCharacterIndex != -1)
        {
            listOfCharacters[selectedCharacterIndex].tag = "Player";
            listOfCharacters[selectedCharacterIndex].GetComponentInParent<PlayerMovement>().animator = listOfCharacters[selectedCharacterIndex].GetComponents<Animator>()[0];
            listOfCharacters[selectedCharacterIndex].GetComponent<EnemyMovement>().enabled = false;
            listOfCharacters[selectedCharacterIndex].GetComponent<Movement>().enabled = false;
            listOfCharacters[selectedCharacterIndex].GetComponent<NavMeshAgent>().enabled = false;
            Destroy(listOfCharacters[selectedCharacterIndex].GetComponent<Rigidbody>());
            listOfCharacters[selectedCharacterIndex].SetActive(true);
        }

        for (int i = 0; i < listOfCharacters.Length; i++)
        {
            if (i == selectedCharacterIndex || i == 2)
            {

            }
            else
            {
                charactersToPopulate.Add(modelPrefabs[i]);
            }
        }
    }

}
