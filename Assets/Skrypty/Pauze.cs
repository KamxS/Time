using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauze : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool PauseActive;

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
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseActive)
        {
            pauseCanvas.SetActive(false);
            PauseActive = false;
        }

        if (PauseActive)
        {
            Time.timeScale = 0f;
        }
        else
            Time.timeScale = 1f;

    }
}
