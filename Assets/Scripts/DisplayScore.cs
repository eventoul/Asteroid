using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TMP_Text gameScoreText;
    [SerializeField] private TMP_Text highScoreText;

    private const string GAME_SCORE = "GameScore";
    private const string HIGH_SCORE = "HighScore";
    
    private void Start()
    {
        DisplayGameScore();
    }

    private void DisplayGameScore()
    {
        int gameScore = PlayerPrefs.GetInt(GAME_SCORE, 0);
        gameScoreText.text = $"Your Score: {gameScore}";
        
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        highScoreText.text = $"High Score: {highScore}";
    }
}
