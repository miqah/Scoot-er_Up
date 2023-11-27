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
        ScoreManager scoreManager = ScoreManager.Instance;

        if (scoreManager != null)
        {
            string leaderboardText = "";

            foreach (ScoreManager.ScoreEntry scoreEntry in scoreManager.GetScores())
            {
                leaderboardText += $"{scoreEntry.playerName}: {scoreEntry.time:F3}\n";
            }

            this.leaderboardText.text = leaderboardText;
        }
    }

    public void ClearLeaderboard()
    {
        ScoreManager.Instance.ClearLeaderboard();
        this.leaderboardText.text = "";
    }
}
