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
    public GameObject gameOverPanel;

    [Header("Кнопка Disagree")]
    public Button disagreeButton;
    public GameObject disagreePanel;

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
            attemptsText.text = " " + currentAttempts;

        if (timerText != null)
            timerText.text = " " + Mathf.Ceil(currentTime);

        if (disagreeButton != null)
        {
            disagreeButton.interactable = false;
            disagreeButton.onClick.AddListener(OnDisagreeClicked);
        }

        if (disagreePanel != null)
            disagreePanel.SetActive(false);

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;

        if (timerText != null)
            timerText.text = " " + Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void FoundDifference()
    {
        foundDifferences++;
        if (disagreeButton != null && foundDifferences > 0)
            disagreeButton.interactable = true;
    }

    public void MissClick()
    {
        if (isGameOver) return;

        currentAttempts--;

        if (attemptsText != null)
            attemptsText.text = " " + currentAttempts;

        if (currentAttempts <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }

    private void OnDisagreeClicked()
    {
        if (disagreePanel != null)
            disagreePanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}