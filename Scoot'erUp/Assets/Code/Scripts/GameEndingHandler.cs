using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
    [SerializeField]
    GameObject dialogBox;

    [SerializeField]
    TimeUpScript timer;

    [SerializeField]
    Button button1;

    [SerializeField]
    Button button2;

    [SerializeField]
    Leaderboard leaderboard;

    [SerializeField]
    InputField playerNameInput;

    [SerializeField]
    Canvas leaderboardCanvas;

    [SerializeField]
    Button submitButton;

    public string playerTag = "Player";
    public Text winText;
    private double finalTime;

    private void Start()
    {
        winText.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        dialogBox.gameObject.SetActive(false);
        playerNameInput.gameObject.SetActive(false);
        leaderboardCanvas.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
        button1.onClick.AddListener(GoToMainMenu);
        button2.onClick.AddListener(RestartScene);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            finalTime = ShowWinText();
            Time.timeScale = 0f;
            leaderboardCanvas.gameObject.SetActive(true);

            if (ScoreManager.Instance.IsPlayerScoreTop5(finalTime))
            {
                playerNameInput.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true);
            }
            else
            {   
                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(true);
                leaderboard.UpdateLeaderboard();
            }
        }
    }

    private double ShowWinText()
    {
        winText.gameObject.SetActive(true);
        double elapsedTime = timer.getElapsedTime();
        int hours = (int)(elapsedTime / 3600);
        int minutes = (int)((elapsedTime % 3600) / 60);
        int seconds = (int)(elapsedTime % 60);

        string formattedTime = $"{hours:00}/{minutes:00}/{seconds:00}";

        winText.text = "Your time was:\n" + formattedTime;

        dialogBox.gameObject.SetActive(false);

        return elapsedTime;
    }

    public void SubmitName()
    {
        string playerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            ScoreManager.Instance.Record(playerName, finalTime);
            playerNameInput.gameObject.SetActive(false);
            submitButton.gameObject.SetActive(false);
            leaderboard.UpdateLeaderboard();
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
        }
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
