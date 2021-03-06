﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform player;
        float moveSpeed = 6.0f;
        float rotationSpeed = 3.0f;
        float range = 10.0f;
        float range2 = 10.0f;
        float stop = 4;
        Transform myTransform;
        private Vector3 wayPointPosition;

        public Text scoreText;
        int score;
        public bool inContact = false;

        private float speed = 6.0f;

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        void Awake ()
        {            
           
            myTransform = transform;
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if(!inContact)
                {
                    //EnableLightSource();
                    this.GetComponent<Movement>().enabled = false;
                   
                    
                }
                inContact = true;
                GameObject go = GameObject.FindWithTag("Player");
                go.GetComponentInParent<PlayerMovement>().UpdateScore();
            }
        }

        void Update ()
        {
            if(inContact)
            {
                float distance = Vector3.Distance(myTransform.position, player.parent.position);

                if (distance <= stop)
                {
                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                    Quaternion.LookRotation(player.parent.position - myTransform.position), rotationSpeed * Time.deltaTime);
                }
                else
                {
                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                    Quaternion.LookRotation(player.parent.position - myTransform.position), rotationSpeed * Time.deltaTime);

                    //move towards the player
                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                }
            }

        }

        void EnableLightSource() {
            foreach (Transform child in transform)
            {
                if (child.tag == "NurseGlow")
                {
                    // the code here is called 
                    // for each child named Bone
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}