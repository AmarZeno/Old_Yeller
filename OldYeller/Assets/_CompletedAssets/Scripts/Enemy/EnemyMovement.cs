using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform player;
        float moveSpeed = 3.0f;
        float rotationSpeed = 3.0f;
        float range = 10.0f;
        float range2 = 10.0f;
        float stop = 2;
        Transform myTransform;
        private Vector3 wayPointPosition;

        private float speed = 6.0f;

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        void Awake ()
        {            
            myTransform = transform;
        }


        void Update ()
        {
            //float distance = Vector3.Distance(myTransform.position, player.position);
            //if (distance <= range2 && distance >= range)
            //{
            //    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            //    Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
            //}


            //else if (distance <= range && distance > stop)
            //{

            //    //move towards the player
            //    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            //    Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
            //    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            //}
            //else if (distance <= stop)
            //{
            //    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            //    Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
            //}

            float distance = Vector3.Distance(myTransform.position, player.position);

            if(distance <= stop)
            {
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
            }
            else
            {
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);

                //move towards the player
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
           
        }
    }
}