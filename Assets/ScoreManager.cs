using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public int highscore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        Instance = this;

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
    }

    public void AddScore(int value)
    {
        score += value;

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }

        UpdateUI();
    }
    
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highscoreText.text = "Highscore: " + highscore;
    }
    
}
