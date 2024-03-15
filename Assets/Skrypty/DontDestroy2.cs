using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy2 : MonoBehaviour
{
    public Slider _sfxSlider;
    public Slider _musicSlider;

    private const string SFXVolumeKey = "SFXVolume";
    private const string MusicVolumeKey = "MusicVolume";

    void Start()
    {
        _sfxSlider.value = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);
        _musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);

        SetSFXVolume(_sfxSlider.value);
        SetMusicVolume(_musicSlider.value);
    }

    public void SetSFXVolume(float volume)
    {
        SoundManager2.Instance.SFXVolume(_sfxSlider.value);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }

    public void SetMusicVolume(float volume)
    {
        SoundManager2.Instance.MusicVolume(_musicSlider.value);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}