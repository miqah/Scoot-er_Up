using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text leaderboardText;

    private void Start()
    {
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        ScoreManager scoreManager = ScoreManager.instance;

        if (scoreManager != null)
        {
            string leaderboardText = "Leaderboard\n";

            foreach (PlayerScore playerScore in scoreManager.GetScores())
            {   
                leaderboardText += $"{playerScore.playerName}: {playerScore.time}\n";
            }

            this.leaderboardText.text = leaderboardText;
        }

    }

}
