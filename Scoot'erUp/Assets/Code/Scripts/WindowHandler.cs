using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHandler : MonoBehaviour
{
    [SerializeField] Canvas windowCanvas;

    public void Show()
    {
        SetCanvasVisibility(true);
    }

    public void Hide()
    {
        SetCanvasVisibility(false);
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
}