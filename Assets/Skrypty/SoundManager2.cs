using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SoundManager2 : MonoBehaviour
{
    public static SoundManager2 Instance;

    public Sound2[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static bool muteMusic = false;
    public static bool muteSfx = false;
    public static float VolumeMusic;
    public static float VolumeSFX;

    public bool isMenu;
    // public PauseMenu pauseMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (isMenu)
        {
            PlayMusic("menu");
        }
        else
            PlayMusic("sound2");
    }

    public void PlayMusic(string name)
    {
        Sound2 s = Array.Find(musicSounds, x => x.NameSound == name);

        if (s == null)
        {
            Debug.Log("Song not found");
        }
        else
        {
            musicSource.clip = s.Clip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        Sound2 s = Array.Find(sfxSounds, x => x.NameSound == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.Clip);
        }
    }

    private void Update()
    {
        if (muteMusic)
        {
            musicSource.mute = true;
        }
        else
            musicSource.mute = false;

        if (muteSfx)
        {
            sfxSource.mute = true;
        }
        else
            sfxSource.mute = false;

    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float VolumeMusic)
    {
        musicSource.volume = VolumeMusic;
    }

    public void SFXVolume(float VolumeSFX)
    {
        sfxSource.volume = VolumeSFX;
    }
}
