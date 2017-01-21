using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{

    public Image[] characters;
    public int currentCharacterIndex;
    public  int maxCharacterIndex;

    private MicrophoneInput mikeInput;
    public float mikeThreshold;
    void Start() {
        maxCharacterIndex = characters.Length;
        mikeInput = gameObject.GetComponent<MicrophoneInput>();
    }

    void Update() {

        if(mikeInput.MicLoudness > mikeThreshold) {
            PlayerPrefs.SetInt("characters", currentCharacterIndex);
            Application.LoadLevel("Basic");
        }

        /*go left*/
        if (InputManager.Xbutton()) {
            if (currentCharacterIndex < 1) {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex = maxCharacterIndex - 1;
            }else {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex--;
            }
            characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1f);
        }
 
        /*go right*/
        if(InputManager.Bbutton()) {
            if (currentCharacterIndex >= maxCharacterIndex - 1) {                
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex = 0;
            }
            else { 
                characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                currentCharacterIndex++;
            }
            characters[currentCharacterIndex].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1f);
            
        }
    }
}