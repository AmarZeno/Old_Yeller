using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        private GameObject wayPoint;
        private Vector3 wayPointPosition;

        private float speed = 6.0f;

        void Start()
        {

        }

        void Awake ()
        {
            // Set up the references.
            wayPoint = GameObject.Find("WayPoint");
        }


        void Update ()
        {
            wayPointPosition = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            if (wayPointPosition != transform.position)
                transform.position = Vector3.MoveTowards(transform.position, wayPointPosition, speed * Time.deltaTime);
            else
                transform.position = transform.up;
        }
    }
}