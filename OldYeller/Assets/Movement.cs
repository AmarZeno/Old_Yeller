using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

   // public Transform track;
    private float moveSpeed = 1f;
    bool characterMoved = false;

    Vector3 origin;
    float maxMoveDistance = 5;

	// Use this for initialization
	void Start () {
        origin = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCharacter();
    }

    void MoveCharacter() {

        Vector3 destination = origin;

        if (characterMoved == false)
        {
            destination.x = origin.x + maxMoveDistance;

            float move = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, destination, move);

            if(transform.position.x >= (origin.x + maxMoveDistance))
                 characterMoved = true;
        }
        else  {
            destination.x = (transform.position.x - origin.x) <= 0 ? origin.x + maxMoveDistance:origin.x;

            float move = moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, destination, move);

            if (transform.position.x <= (origin.x))
                characterMoved = false;
        }
    }
}
