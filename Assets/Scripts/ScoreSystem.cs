using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;

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
}
