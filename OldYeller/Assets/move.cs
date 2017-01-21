using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public Transform track;
    private float moveSpeed = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float move = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, track.position, moveSpeed);
	}
}
