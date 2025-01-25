using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isMenu = false;
    public GameObject menu;
    public GameObject reallyToMenu;

    public GameObject settings;

    private void Update()
    {
        Menu();
    }

    public void MobileMenu()
    {
        isMenu = !isMenu;
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = !isMenu;
        }
        if (isMenu == true)
        {
            menu.SetActive(isMenu);
            Time.timeScale = 0f;
        }
        else
        {
            menu.SetActive(isMenu);
            settings.SetActive(false);
            reallyToMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public void Continue()
    {
        isMenu = !isMenu;
        reallyToMenu.SetActive(false);
    }

    public void ReallyToMenu()
    {
        reallyToMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ToSettings()
    {
        settings.SetActive(true);
    }
}
