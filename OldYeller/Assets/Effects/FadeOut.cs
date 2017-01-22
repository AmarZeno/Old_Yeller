using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
    public float alphaLevel = 1f;
    Color temp;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        temp = GetComponent<Renderer>().material.color;
        if (alphaLevel != 0.0)
        {
            alphaLevel -= 0.005f;
            temp = new Color(0f, 0f, 0f, alphaLevel);
        }
        GetComponent<Renderer>().material.color = temp;
    }
}
