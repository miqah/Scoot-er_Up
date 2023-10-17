using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{   
    [SerializeField] GameObject dialogBox;
    [SerializeField] TimeUpScript timer;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    public string playerTag = "Player"; 
    public Text winText; 

    private void Start()
    {
        winText.gameObject.SetActive(false);
        
        button1.gameObject.SetActive(false);
        
        button2.gameObject.SetActive(false);
        
        dialogBox.gameObject.SetActive(false);

        button1.onClick.AddListener(GoToMainMenu);

        button2.onClick.AddListener(RestartScene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {   
            ShowWinText();
        }
    }

    void ShowWinText()
    {   
        winText.gameObject.SetActive(true);
        double elapsedTime = timer.getElapsedTime();
        int hours = (int)(elapsedTime / 3600);
        int minutes = (int)((elapsedTime % 3600) / 60);
        int seconds = (int)(elapsedTime % 60);

        string formattedTime = $"Hours: {hours:00} Minutes: {minutes:00} Seconds: {seconds:00}";
    
        winText.text = "You Win!\nYour time was:\n" + formattedTime;

        button1.gameObject.SetActive(true);
        
        button2.gameObject.SetActive(true);
        
        dialogBox.gameObject.SetActive(true);
        
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); 
    }

    void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}