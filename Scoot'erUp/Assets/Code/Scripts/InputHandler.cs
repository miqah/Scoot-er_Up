using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] DragAndShoot dragAndShoot;
    private bool isPaused = false;

    private void Update()
    {   
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {   

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
