using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowHandler : MonoBehaviour
{
    [SerializeField]
    Canvas windowCanvas;
    
    [SerializeField] SoundManager soundManager;

    public void Show()
    {
        SetCanvasVisibility(true);
        soundManager.PlaySound("click");
    }

    public void Hide()
    {
        SetCanvasVisibility(false);
        soundManager.PlaySound("click");
    }

    private void SetCanvasVisibility(bool isVisible)
    {
        if (windowCanvas != null)
        {
            windowCanvas.enabled = isVisible;
        }
    }

    public void Start()
    {
        SetCanvasVisibility(false);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        soundManager.PlaySound("click");
    }
}
