using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using CompleteProject;

public class PlayerMovement : MonoBehaviour
{
    float controllerSpeed = 20;            // The controllerSpeed that the player will move at.
    public bool playerMoving = false;
    float timeStopped = 10000;
    public float yellThreshold;
    public float GameTime;
    float StartTime;
    public bool GameOver = false;
    public GameObject EndGameCanvas;
    public GameObject GameHUD;

    float h;
    float v;


    private MicrophoneInput mikeInput;

    public int score = 0;
    Text scoreText;
    Text timeText;

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

    public Animator animator;
    public Vector3 lastPosition;

    void Awake ()
    {
#if !MOBILE_INPUT
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");
#endif
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // Set up references.
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
        mikeInput = GameObject.FindGameObjectWithTag("Yeller").GetComponent<MicrophoneInput>();
        
        timeText = GameObject.Find("TimeText").GetComponent<Text>();

    }

    void Start()
    {
        StartTime = Time.timeSinceLevelLoad;
    }


    void FixedUpdate ()
    {           
        // Store the input axes.
        //float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        //float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // Move the player around the scene.
        

        // Turn the player to face the mouse cursor.
        //Turning ();

        // Animate the player.
        //Animating (h, v);

        // Xbox one controller input
        JoystickInput();
        Move (h, v);
        LookTowardsDirection(h, v);

        CheckForShit();

        TimeManager();
    }


    void Move (float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);
            
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * controllerSpeed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
    }


    public void IncreaseScore()
    { 
        score++;
        //score++;
        scoreText.text = "Score: " + score;
    }


    public void UpdateScore()
    {
        ArrayList totalPeople = new ArrayList();
        List<GameObject> listOfFollowingPeople = new List<GameObject>();

        totalPeople.AddRange(GameObject.FindGameObjectsWithTag("People"));

        foreach (GameObject person in totalPeople)
        {
            if (person.GetComponent<EnemyMovement>().inContact == true)
            {
                if (!listOfFollowingPeople.Contains(person))
                    listOfFollowingPeople.Add(person);

            }
        }

        scoreText.text = "Score: " + listOfFollowingPeople.Count;
        score = listOfFollowingPeople.Count;

    }

    public void DecreaseScore()
    {

        score--;
        //score++;
        scoreText.text = "Score: " + score;

    }

    void Turning ()
    {
#if !MOBILE_INPUT
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotatation);
        }
#else

        Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));

        if (turnDir != Vector3.zero)
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotatation);
        }
#endif
    }


    public void LookTowardsDirection(float horizontal, float vertical)
    {
        Debug.Log("Horizontal: " + horizontal + " Vertical: " + vertical);
        //var direction = transform.position - lastPosition;
        //var localDirection = transform.InverseTransformDirection(direction);
        //lastPosition = transform.position;
        //// transform.LookAt(localDirection);



        //if (localDirection != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(localDirection);

        //    playerRigidbody.MoveRotation(newRotation);
        //}

        if (vertical > 0)
        {

            if (horizontal > 0)
            {
                // I quadrant
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(1f, 0f, 1f));
                playerRigidbody.MoveRotation(newRotation);
            }
            else if (horizontal < 0)
            {
                // II quadrant
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(-1f, 0f, 1f));
                playerRigidbody.MoveRotation(newRotation);
            }
            else
            {
                // transform.forward = new Vector3(0f, 0f, 1f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(0f, 0f, 1f));
                playerRigidbody.MoveRotation(newRotation);
            }
        }
        else if (vertical < 0)
        {
            if (horizontal > 0)
            {
                // IV quadrant
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(1f, 0f, -1f));
                playerRigidbody.MoveRotation(newRotation);
            }
            else if (horizontal < 0)
            {
                // III quadrant
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(-1f, 0f, -1f));
                playerRigidbody.MoveRotation(newRotation);
            }
            else
            {
                // transform.forward = new Vector3(0f, 0f, -1f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(0f, 0f, -1f));
                playerRigidbody.MoveRotation(newRotation);
            }
        }
        else if (horizontal > 0)
        {
            if (vertical > 0)
            {
                // I quadrant
                transform.forward = new Vector3(1f, 0f, 1f);
            }
            else if (vertical < 0)
            {
                // II quadrant
                transform.forward = new Vector3(-1f, 0f, 1f);
            }
            else
            {
                transform.forward = new Vector3(1f, 0f, 0f);
            }
        }
        else if (horizontal < 0)
        {
            if (vertical > 0)
            {
                // IV quadrant
                transform.forward = new Vector3(1f, 0f, -1f);
            }
            else if (vertical < 0)
            {
                // III quadrant
                transform.forward = new Vector3(-1f, 0f, -1f);
            }
            else
            {
                transform.forward = new Vector3(-1f, 0f, 0f);
            }
        }

        AnimateCharacter(horizontal, vertical);
    }

    public void AnimateCharacter(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void JoystickInput()
    {
        if (InputManager.MainHorizontal() < -0.5f && transform.position.z > -25)
        {
            //transform.Translate(Vector3.back * Time.deltaTime * controllerSpeed);
            playerMoving = true;
            CheckForYell();
            h = InputManager.MainHorizontal();
            timeStopped = Time.timeSinceLevelLoad;

        }
        else if (InputManager.MainHorizontal() > 0.5f && transform.position.z < 25)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * controllerSpeed);
            playerMoving = true;
            CheckForYell();
            h = InputManager.MainHorizontal();
            timeStopped = Time.timeSinceLevelLoad;

        }
        else
        {
            playerMoving = false;
            h = 0;
        }

        if (InputManager.MainVertical() < -0.5f && transform.position.x > -25)
        {
            //transform.Translate(Vector3.left * Time.deltaTime * controllerSpeed);
            playerMoving = true;
            CheckForYell();
            v = -(InputManager.MainVertical());
            timeStopped = Time.timeSinceLevelLoad;
        }
        else if (InputManager.MainVertical() > 0.5f && transform.position.x < 25)
        {
            //transform.Translate(Vector3.right * Time.deltaTime * controllerSpeed);
            playerMoving = true;
            CheckForYell();
            v = -(InputManager.MainVertical());
            timeStopped = Time.timeSinceLevelLoad;
        }
        else
        {
            playerMoving = false;
            v = 0;
        }
    }

    void CheckForYell()
    {
        if (mikeInput.MicLoudness > yellThreshold)
        {
            timeStopped = Time.timeSinceLevelLoad;
        }
        else
        {
            timeStopped = 0;
        }
    }


    void CheckForShit()
    {
        float timeTilShit = 0;

        if (mikeInput.MicLoudness > yellThreshold && playerMoving == false)
        {
                timeTilShit = Time.timeSinceLevelLoad - timeStopped;
        }

        if(timeTilShit >2.5f)
        {
            GameOver = true;
            GameHUD.SetActive(false);
            EndGameCanvas.SetActive(true);
        }
    }

    void TimeManager()
    {
        GameTime = Time.timeSinceLevelLoad - StartTime;

        GameTime = Mathf.Round(GameTime * 10f) / 10f;
        timeText.text = "Time: " + GameTime;

        if (GameTime > 15 && GameOver == false)
        {
            GameOver = true;
            score = 0;
            GameHUD.SetActive(false);
            EndGameCanvas.SetActive(true);
        }

    }
}
