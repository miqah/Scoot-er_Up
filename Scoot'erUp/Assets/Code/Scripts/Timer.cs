using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpScript : MonoBehaviour
{
    [SerializeField] Text timerText;
    private float elapsedTime = 0.0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + elapsedTime.ToString("F2"); 
    }

    public float getElapsedTime()
    {
        return elapsedTime;
    }
}
