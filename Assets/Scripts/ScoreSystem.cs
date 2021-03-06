using System;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;
    private const string GAME_SCORE = "GameScore";
    private const string HIGH_SCORE = "HighScore";

    // Update is called once per frame
    private void Update()
    {
        GameScoreDisplay();
    }

    private void GameScoreDisplay()
    {
        score += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(GAME_SCORE, Mathf.FloorToInt(score)); // apo8ikeysh toy score toy paixnidiou sto GAME_SCORE.

        int currentHighScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, Mathf.FloorToInt(score));
        }
    }
}
