using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TMP_Text gameScoreText;

    private const string GAME_SCORE = "GameScore";
    
    private void Start()
    {
        DisplayGameScore();
    }

    private void DisplayGameScore()
    {
        int gameScore = PlayerPrefs.GetInt(GAME_SCORE, 0);
        gameScoreText.text = $"Your Score: {gameScore}";
    }
}
