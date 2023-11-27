using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] SoundManager soundManager;
     
    public void Pause()
    {
       pauseMenu.SetActive(true);
       Time.timeScale = 0f;
       soundManager.PlaySound("closeMenu");
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;  
        soundManager.PlaySound("closeMenu");
    }
}
