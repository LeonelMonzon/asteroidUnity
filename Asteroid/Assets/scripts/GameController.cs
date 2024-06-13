using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverPanel;
    public Text finalScoreText;
    public GameObject player;

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
        FindPlayer(); // Encuentra al jugador al iniciar
    }

    void FindPlayer()
    {
        player = GameObject.FindWithTag("Player"); // Suponiendo que tu nave tiene el tag "Player"
    }
    public void GameOver()
    {
        Time.timeScale = 0; // Pausa el juego
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + GameManager.instance.GetScore().ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Reanuda el juego
        GameManager.instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
        Invoke("FindPlayer", 0.1f);
    }
}
