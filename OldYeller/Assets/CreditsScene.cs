using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour {

    public void GoToCredts() {
        SceneManager.LoadScene("Credits");
    }
}
