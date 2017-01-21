using UnityEngine;
using System.Collections;

public class YellStart : MonoBehaviour {

    public float yellThreshold;
    private MicrophoneInput mikeInput;

    void Start() {
        mikeInput = gameObject.GetComponent<MicrophoneInput>();
    }

    void Update() {
        if(mikeInput.MicLoudness > yellThreshold) {
            ChangeScene();
        }
    }

    private void ChangeScene() {
        Application.LoadLevel("Basic");
    }
}
