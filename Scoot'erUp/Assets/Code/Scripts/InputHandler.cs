using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] DragAndShoot dragAndShoot;
    
    private void FixedUpdate()
    {   
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {    
        // float direction = 0f;
        // if (Input.GetKey(KeyCode.D))
        // {
        //    direction = 1f;
        // }
        // else if (Input.GetKey(KeyCode.A))
        // {
        //    direction = -1f;
        // }

        // playerMovement.MoveCharacter(direction);
        if (Input.GetKey(KeyCode.S))
        {
           playerMovement.StopCharacter();
        }  

        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

  
}
