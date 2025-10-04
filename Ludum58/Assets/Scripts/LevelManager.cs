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
    public GameObject winPanel;
    public GameObject gameOverPanel;

    [Header("Таймер")]
    public float levelTime = 90f;
    private float currentTime;
    private bool isGameOver = false;

    void Start()
    {
        currentTime = levelTime;
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
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