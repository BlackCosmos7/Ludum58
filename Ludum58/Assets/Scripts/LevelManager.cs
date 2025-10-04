using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Настройки уровня")]
    public int totalDifferences = 7;
    private int foundDifferences = 0;

    [Header("UI элементы")]
    public Text timerText;
    public Text attemptsText;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    [Header("Таймер")]
    public float levelTime = 90f;
    private float currentTime;
    private bool isGameOver = false;

    [Header("Ошибки")]
    public int maxAttempts = 3;
    private int currentAttempts;

    void Start()
    {
        currentTime = levelTime;
        currentAttempts = maxAttempts;

        if (attemptsText != null)
            attemptsText.text = "Попытки: " + currentAttempts;

        if (timerText != null)
            timerText.text = "Время: " + Mathf.Ceil(currentTime);

        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;

        if (timerText != null)
            timerText.text = "Время: " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void FoundDifference()
    {
        foundDifferences++;

        if (foundDifferences >= totalDifferences)
        {
            Win();
        }
    }

    public void MissClick()
    {
        if (isGameOver) return;

        currentAttempts--;

        if (attemptsText != null)
            attemptsText.text = "Попытки: " + currentAttempts;

        if (currentAttempts <= 0)
        {
            GameOver();
        }
    }

    void Win()
    {
        winPanel.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", currentScene + 1);
        PlayerPrefs.Save();
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextLevel = PlayerPrefs.GetInt("LastLevel", 2);
        SceneManager.LoadScene(nextLevel);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}