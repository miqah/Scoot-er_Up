using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayerManager : MonoBehaviour
{
    [SerializeField]
    private Button resetButton;

    [SerializeField]
    Timer timer;

    [SerializeField]
    SoundManager soundManager;

    private Vector3 defaultPlayerPosition = new Vector3(-13.2f, -5.54f, 0f);

    public void ResetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = defaultPlayerPosition;
        PlayerPrefs.SetFloat("PlayerPositionX", defaultPlayerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", defaultPlayerPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", defaultPlayerPosition.z);
        PlayerPrefs.SetFloat("TimerCount", 0);
        timer.setElapsedTime(0);
        soundManager.PlaySound("click");

        PlayerPrefs.Save();
    }
}
