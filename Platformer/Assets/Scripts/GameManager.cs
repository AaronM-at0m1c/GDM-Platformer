using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;

    private int score = 0;
    private int health = 100;
    public int finalScore = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        onScoreChanged?.Invoke(score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            finalScore = score;
            onGameOver?.Invoke();
        }
    }

    public void TriggerGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ResetGame()
    {
        score = 0;
        health  = 100;
    }
}
