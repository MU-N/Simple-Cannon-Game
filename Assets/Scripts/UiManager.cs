using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager: MonoBehaviour
{
    [SerializeField] GameObject loseMenu;


    public void OnLose()
    {
        Cursor.lockState = CursorLockMode.None;
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnRestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void OnResumeGame()
    {
        Time.timeScale = 1;
        loseMenu.SetActive(false);

    }

    public void OnExit()
    {
        Application.Quit();
    }

}
