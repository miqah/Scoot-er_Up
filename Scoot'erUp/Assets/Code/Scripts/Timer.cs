using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timerText;
    private float elapsedTime = 0.0f;

    public void Awake()
    {
        elapsedTime = PlayerPrefs.GetFloat("TimerCount");
    }

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

    public void setElapsedTime(float time)
    {
        elapsedTime = time;
    }
}
