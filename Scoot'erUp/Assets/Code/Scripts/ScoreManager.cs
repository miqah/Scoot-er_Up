using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScore
{
    public string playerName;
    public double time;
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private List<PlayerScore> scores = new List<PlayerScore>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(string playerName, double time)
    {
        PlayerScore playerScore = new PlayerScore { playerName = playerName, time = time };

        LoadScores();

        bool isNewHighScore = false;

        for (int i = 0; i < scores.Count; i++)
        {
            if (time > scores[i].time)
            {
                scores.Insert(i, playerScore);
                scores.RemoveAt(scores.Count - 1);

                isNewHighScore = true;
                break;
            }
        }

        if (!isNewHighScore)
        {
            Debug.Log("The new score is not higher than the top 5 scores. No update needed.");
            return;
        }

        // Sort the list in descending order based on time (just to be sure)
        scores = scores.OrderByDescending(score => score.time).ToList();

        SaveScores();

        Debug.Log($"Score added: PlayerName: {playerName}, Time: {time}");

        Debug.Log("Top 5 Scores:");
        foreach (var score in scores)
        {
            Debug.Log($"PlayerName: {score.playerName}, Time: {score.time}");
        }
    }

    public List<PlayerScore> GetScores()
    {
        LoadScores();
        return scores;
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("PlayerScores", json);

        Debug.Log("Scores saved");
    }

    private void LoadScores()
    {
        string json = PlayerPrefs.GetString("PlayerScores");
        scores = JsonUtility.FromJson<List<PlayerScore>>(json);

        if (scores == null)
        {
            scores = new List<PlayerScore>();
        }

        Debug.Log("Scores loaded");
    }
}
