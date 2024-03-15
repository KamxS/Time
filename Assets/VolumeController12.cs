using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController12 : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        SoundManager2.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        SoundManager2.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        SoundManager2.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        SoundManager2.Instance.SFXVolume(_sfxSlider.value);
    }


}

