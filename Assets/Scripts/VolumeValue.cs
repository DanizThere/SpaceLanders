using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public AudioMixer vol;
    public Slider slider;
    public void SetLevelMusic()
    {
        float sliderValue = slider.value;
        vol.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Vol", sliderValue);
    }
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Vol", 0.75f);
    }
}
