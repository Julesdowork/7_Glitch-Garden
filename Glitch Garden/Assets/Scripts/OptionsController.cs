﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    public void UpdateVolume()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
            PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found. Did you start from Start?");
        }
    }

    public void RestoreDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
