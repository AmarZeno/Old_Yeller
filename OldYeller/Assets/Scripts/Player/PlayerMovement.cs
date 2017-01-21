using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 10;
    
    private void Update()
    {
        //if (InputManager.Abutton())
        //{
             
        //}

        if (InputManager.MainHorizontal() < -0.5f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (InputManager.MainHorizontal() > 0.5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            
        }

        if (InputManager.MainVertical() < -0.5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime*speed);
        }
        else if (InputManager.MainVertical() > 0.5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else
        {

        }
    }
    
}
