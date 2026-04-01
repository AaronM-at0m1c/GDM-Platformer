using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField playerNameInput;

    void Start()
    {
        int finalScore = GameManager.Instance.finalScore;
        scoreText.text = "Final Score: " + finalScore;        
    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;
        
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }
        
        int finalScore = GameManager.Instance.finalScore;
        float completionTime = Time.timeSinceLevelLoad;
        
        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);
        
        SceneManager.LoadScene("HighScores");
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
