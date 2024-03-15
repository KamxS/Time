using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu2 : MonoBehaviour
{
    public string SampleScene;
    public GameObject uiSettings;
    public GameObject uiCredtis;

    public void Play()
    {
        SoundManager2.Instance.PlaySFX("Switch");
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager2.Instance.PlaySFX("Switch");
    }

    public void Credtis()
    {
        Debug.Log("Credits");
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager2.Instance.PlaySFX("Switch");
    }

    public void SettingsBacktoMenu()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager2.Instance.PlaySFX("Switch");
    }

    public void cREDITSBacktoMenu()
    {
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager2.Instance.PlaySFX("Switch");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
