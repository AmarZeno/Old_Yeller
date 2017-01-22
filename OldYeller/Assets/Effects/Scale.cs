using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

    private MicrophoneInput mikeInput;

    public float speed = 5f;
    public float maxSize = 2f;
    public float minSize = 0.2f;
    Vector3 temp;
    // Use this for initialization
    void Start () {
        mikeInput = GameObject.FindGameObjectWithTag("Yeller").GetComponent<MicrophoneInput>();
    }
	
	// Update is called once per frame
	void Update () {

        maxSize = mikeInput.MicLoudness;
        float range = maxSize - minSize;
        temp = transform.localScale;
        if (temp.x < 3*range) {
            temp.x += Time.deltaTime * speed;
            temp.y += Time.deltaTime * speed;
            temp.z += Time.deltaTime * speed;
        } 
        transform.localScale = temp;
	}
}
