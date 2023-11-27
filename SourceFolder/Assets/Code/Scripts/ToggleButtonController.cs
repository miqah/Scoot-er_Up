using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleButtonController : MonoBehaviour
{
    [SerializeField]
    Text counterText;

    [SerializeField]
    Toggle timerToggle;

    [SerializeField]
    Toggle fullscreenToggle;

    [SerializeField]
    Text labelText;

    [SerializeField]
    Text fullScreenText;

    [SerializeField]
    Text distanceText;

    [SerializeField]
    Toggle distanceToggle;

    [SerializeField]
    Text distanceTextInUI;

    private const string counterTextKey = "counterText";
    private const string fullscreenKey = "fullscreen";
    private const string distanceTextKey = "distanceText";

    public void ChangeText()
    {
        if (timerToggle.isOn)
        {
            PlayerPrefs.SetInt(counterTextKey, 0);
            counterText.enabled = true;
            labelText.text = "TIMER ON";
        }
        else
        {
            PlayerPrefs.SetInt(counterTextKey, 1);
            counterText.enabled = false;
            labelText.text = "TIMER OFF";
        }
    }

    public void ChangeTextMainMenu()
    {
        if (timerToggle.isOn)
        {
            PlayerPrefs.SetInt(counterTextKey, 0);
            labelText.text = "TIMER ON";
        }
        else
        {
            PlayerPrefs.SetInt(counterTextKey, 1);
            labelText.text = "TIMER OFF";
        }
    }

    public void ChangeFullscreen()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt(fullscreenKey, 0);
            fullScreenText.text = "FULLSCREEN ON";
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt(fullscreenKey, 1);
            fullScreenText.text = "FULLSCREEN OFF";
        }
    }

    public void ToggleDistanceText()
    {
        if (distanceToggle.isOn)
        {
            PlayerPrefs.SetInt(distanceTextKey, 0);
            distanceText.text = "DISTANCE ON";
            distanceTextInUI.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt(distanceTextKey, 1);
            distanceText.text = "DISTANCE OFF";
            distanceTextInUI.enabled = false;
        }
    }

    public void ToggleDistanceTextMainMenu()
    {
        if (distanceToggle.isOn)
        {
            PlayerPrefs.SetInt(distanceTextKey, 0);
            distanceText.text = "DISTANCE ON";
        }
        else
        {
            PlayerPrefs.SetInt(distanceTextKey, 1);
            distanceText.text = "DISTANCE OFF";
        }
    }

    public void Start()
    {
        timerToggle.isOn = PlayerPrefs.GetInt(counterTextKey) == 0;
        fullscreenToggle.isOn = PlayerPrefs.GetInt(fullscreenKey) == 0;
        distanceToggle.isOn = PlayerPrefs.GetInt(distanceTextKey) == 0;
        Screen.fullScreen = fullscreenToggle.isOn;

        if (timerToggle.isOn && SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            counterText.enabled = true;
        }
        else
        {
            counterText.enabled = false;
        }
    }
}
