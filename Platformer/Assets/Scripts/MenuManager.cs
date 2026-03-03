using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
