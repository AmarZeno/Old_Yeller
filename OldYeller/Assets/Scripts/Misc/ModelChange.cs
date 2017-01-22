using UnityEngine;
using System.Collections;

public class ModelChange : MonoBehaviour {

   public GameObject[] listOfCharacters;
    int selectedCharacterIndex = -1;

	// Use this for initialization
	void Start () {
        selectedCharacterIndex = PlayerPrefs.GetInt("characters");
        selectedCharacterIndex = 1;
        if (selectedCharacterIndex != -1)
        {
            listOfCharacters[selectedCharacterIndex].SetActive(true);
            listOfCharacters[selectedCharacterIndex].GetComponentInParent<PlayerMovement>().animator = listOfCharacters[selectedCharacterIndex].GetComponents<Animator>()[0];
        }
    }

}
