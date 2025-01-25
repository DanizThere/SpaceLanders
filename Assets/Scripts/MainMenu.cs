using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject settings;
    public AudioSource click;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsMenuFalse();
        }
        if (SceneLoader.b >= 1)
        {
            startBut.SetActive(false);
            conBut.SetActive(true);
        }
    }

    private void Awake()
    {
        settings = GameObject.Find("Settings");
        settings.SetActive(false);
        PlayerPrefs.GetInt("Clicks");
    }
    public GameObject startBut;
    public GameObject conBut;
    public void LoadScene()
    {
        click.Play();
        SceneManager.LoadScene(1);
        conBut.SetActive(true);
        SceneLoader.b++;
        
    }
    public void SecondScene()
    {
        click.Play();
        SceneManager.LoadScene(2);
    }
    bool set = false;
    public void SettingsMenuTrue()
    {
        set = !set;
        settings.SetActive(set);
        click.Play();
    }
    public GameObject rtd;
    public void SettingsMenuFalse()
    {
        rtd.SetActive(false);
        settings.SetActive(false);
        click.Play();
    }

    public void Exit()
    {
        click.Play();
        Application.Quit();
    }
}
