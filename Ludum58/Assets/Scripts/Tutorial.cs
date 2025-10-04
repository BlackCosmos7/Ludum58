using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour

{
    public GameObject[] panels;
    private int currentIndex = 0;

    void Start()
    {
        ShowPanel(0);
    }

    public void NextPanel()
    {
        panels[currentIndex].SetActive(false);
        currentIndex++;

        if (currentIndex < panels.Length)
        {
            ShowPanel(currentIndex);
        }
        else
        {
            LoadNextScene();
        }
    }

    void ShowPanel(int index)
    {
        panels[index].SetActive(true);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
