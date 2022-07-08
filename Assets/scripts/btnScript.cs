using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnScript : MonoBehaviour
{
    public GameObject pauseBtn; // off at start
    public GameObject resumeBtn; // off at start
    public GameObject fade; // off at start
    public GameObject quitBtn; // off at start


    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        pauseBtn.SetActive(true);
    }

    public void Pause()
    {
        pauseBtn.SetActive(false);
        Time.timeScale = 0;

        resumeBtn.SetActive(true);
        fade.SetActive(true);
        quitBtn.SetActive(true);
    }
    public void Resume()
    {
        resumeBtn.SetActive(false);
        Time.timeScale = 1;
        
        pauseBtn.SetActive(true);
        fade.SetActive(false);
        quitBtn.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
