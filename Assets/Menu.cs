using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string GameScene;
    public GameObject uiSettings;
    public GameObject uiCredtis;

    public void Play()
    {
        SoundManager.Instance.PlaySFX("Switch");
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Click");
    }

    public void Settings()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
        Debug.Log("Click");
    }

    public void Credtis()
    {
        Debug.Log("Credits");
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
        Debug.Log("Click");
    }

    public void SettingsBacktoMenu()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
        Debug.Log("Click");
    }

    public void cREDITSBacktoMenu()
    {
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
        Debug.Log("Click");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Click");
    }
}
