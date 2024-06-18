using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public int score = 0;
    public GameObject extraLifePrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        CheckForExtraLife();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    void CheckForExtraLife()
    {
        if (score % 200 == 0 && score != 0)
        {
            GenerateExtraLife();
        }
    }

    void GenerateExtraLife()
    {
        Vector2 randomPosition = CameraBounds.instance.GetRandomPosition();
        Instantiate(extraLifePrefab, randomPosition, Quaternion.identity);
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = 0;
        UpdateScoreText();
    }
}
