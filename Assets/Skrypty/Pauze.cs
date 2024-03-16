using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool PauseActive;
    float timeScaleBeforePause;

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseActive)
        {
            pauseCanvas.SetActive(true);
            PauseActive = true;
            timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseActive)
        {
            pauseCanvas.SetActive(false);
            PauseActive = false;
            Time.timeScale = timeScaleBeforePause;
        }
    }

    public void menu()
    {
        SoundManager2.Instance.PlaySFX("Switch");
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }


}
