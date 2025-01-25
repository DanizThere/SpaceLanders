using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    private void Start()
    {
        PlayerPrefs.GetInt("Resol");
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    public GameObject reallyToDel;
    public void reallyToDelete()
    {
        reallyToDel.SetActive(true);
    }

    public void ScreenRes(int resolution)
    {
        PlayerPrefs.SetInt("Resol", resolution);
        switch (resolution)
        {
            case 0:
                Screen.SetResolution(800, 600, true);
                break;
            case 1:
                Screen.SetResolution(1024, 800, true);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
            case 3:
                Screen.SetResolution(1440, 1080, true);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
