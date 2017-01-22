using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    public Image[] characters;
    public int currentCharacterIndex;
    public  int maxCharacterIndex;

    private MicrophoneInput mikeInput;
    public float mikeThreshold;

    bool leftSelect = false;
    bool rightSelect = false;
    bool resetSelect = true;
    void Start() {
        maxCharacterIndex = characters.Length;
        mikeInput = gameObject.GetComponent<MicrophoneInput>();
    }

    void Update() {

        if (mikeInput.MicLoudness > mikeThreshold && Time.timeSinceLevelLoad > 1) {
            PlayerPrefs.SetInt("characters", currentCharacterIndex);
            SceneManager.LoadScene("SpawnMerge");
        }

        if (InputManager.MainHorizontal() < -0.5f && transform.position.z > -25)
        {
            leftSelect = true; 
        }
        else if (InputManager.MainHorizontal() > 0.5f && transform.position.z < 25)
        {
            rightSelect = true;
        }
        else
        {
            leftSelect = false;
            rightSelect = false; 
            resetSelect = true;
        }


        /*go left*/
        if (leftSelect && resetSelect) {
            if (currentCharacterIndex < 1) {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex = maxCharacterIndex - 1;
            }else {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex--;
            }
            characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1f);
            resetSelect = false;
        }
 
        /*go right*/
        if(rightSelect && resetSelect) {
            if (currentCharacterIndex >= maxCharacterIndex - 1) {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex = 0;
            }
            else { 
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex++;
            }
            characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1f);
            resetSelect = false;
        }
    }
}