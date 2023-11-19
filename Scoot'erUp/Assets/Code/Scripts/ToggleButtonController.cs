using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleButtonController : MonoBehaviour
{
    [SerializeField] Text counterText;
    [SerializeField] Toggle timerToggle;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Text labelText;
    [SerializeField] Text fullScreenText;
 
    private const string counterTextKey = "counterText";
    private const string fullscreenKey = "fullscreen";

    public void ChangeText()
    {
        if (timerToggle.isOn)
        {
            PlayerPrefs.SetInt(counterTextKey, 0);
            counterText.enabled = true;
            labelText.text = "Timer On";
        }
        else
        {
            PlayerPrefs.SetInt(counterTextKey, 1);
            counterText.enabled = false;
            labelText.text = "Timer Off";
        }
    }

    public void ChangeTextMainMenu()
    {
        if (timerToggle.isOn)
        {
            PlayerPrefs.SetInt(counterTextKey, 0);
            labelText.text = "Timer On";
        }
        else
        {
            PlayerPrefs.SetInt(counterTextKey, 1);
            labelText.text = "Timer Off";
        }
    }

    public void ChangeFullscreen(){
       if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt(fullscreenKey, 0);
            fullScreenText.text = "FullScreen On";
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt(fullscreenKey, 1);
            fullScreenText.text = "FullScreen Off";
        }
    }

    public void Start()
    {
        timerToggle.isOn = PlayerPrefs.GetInt(counterTextKey) == 0;
        
        if (timerToggle.isOn == true && SceneManager.GetActiveScene().name != "MainMenuScene" ) {
          counterText.enabled = true;
        } else {
          counterText.enabled = false;
        }
        fullscreenToggle.isOn = PlayerPrefs.GetInt(fullscreenKey) == 0;

        Screen.fullScreen = fullscreenToggle.isOn;
    }
}