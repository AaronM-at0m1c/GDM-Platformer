using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore = GameManager.Instance.finalScore;
        scoreText.text = "Final Score: " + finalScore;
    }

    public void Retry()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
