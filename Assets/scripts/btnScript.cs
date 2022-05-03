using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnScript : MonoBehaviour
{
    public GameObject pauseBtn;
    public GameObject resumeBtn; // must be of at the start
    public GameObject pauseMenu; // must be of at the start
    public GameObject quitBtn; // must be of at the start


    public void StartTheGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseBtn.SetActive(false);
        Time.timeScale = 0;

        resumeBtn.SetActive(true);
        pauseMenu.SetActive(true);
        quitBtn.SetActive(true);
    }
    public void Resume()
    {
        resumeBtn.SetActive(false);
        Time.timeScale = 1;
        
        pauseBtn.SetActive(true);
        pauseMenu.SetActive(false);
        quitBtn.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
