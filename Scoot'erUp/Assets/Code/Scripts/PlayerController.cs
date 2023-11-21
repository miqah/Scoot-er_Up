using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    DragAndShoot dragAndShoot;
    public Transform finalObject;
    public Transform initialObject;
    public Text percentageText;
    private bool isPaused = false;

    private void Update()
    {
        HandlePlayerInput();
        CalculateDistancePercentage();
    }

    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.StopCharacter();
        }

        // if (Input.GetKey(KeyCode.M))
        // {
        //     SceneManager.LoadScene("MainMenuScene");
        // }
    }

    void CalculateDistancePercentage()
    {
        float totalDistance = Vector2.Distance(initialObject.position, finalObject.position);

        Transform playerTransform = playerMovement.transform;

        if (playerTransform != null)
        {
            float currentDistance = Vector2.Distance(
                playerTransform.position,
                finalObject.position
            );

            float percentage = ((totalDistance - currentDistance) / totalDistance) * 100f;
            percentage = Mathf.Clamp(percentage, 0f, 100f);

            UpdatePercentageText(percentage);
        }
    }

    void UpdatePercentageText(float percentage)
    {
        if (percentageText != null)
        {
            percentageText.text = "Distance: " + percentage.ToString("F1") + "%";
        }
    }
}
