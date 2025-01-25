using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public AudioMixer vol;
    public Slider slider;
    public void SetLevelMusic()
    {
        float sliderValue = slider.value;
        vol.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
    }
}
