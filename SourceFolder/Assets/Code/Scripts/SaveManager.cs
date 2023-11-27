using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    Button saveButton;
    private float counterTimer;
    private Vector3 playerStartPosition;

    [SerializeField]
    Timer timer;

    [SerializeField]
    SoundManager soundManager;

    public void Start()
    {
        LoadPlayerPosition();
    }

    public void SavePlayerPosition()
    {
        playerStartPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        PlayerPrefs.SetFloat("PlayerPositionX", playerStartPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", playerStartPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", playerStartPosition.z);
        SaveTimerCount();
        soundManager.PlaySound("click");
    }

    public void SaveTimerCount()
    {
        PlayerPrefs.SetFloat("TimerCount", timer.getElapsedTime());
    }

    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerPositionX");
        float y = PlayerPrefs.GetFloat("PlayerPositionY");
        float z = PlayerPrefs.GetFloat("PlayerPositionZ");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(x, y, z);
    }
}
