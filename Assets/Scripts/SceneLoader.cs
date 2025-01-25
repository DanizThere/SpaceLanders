using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static int b = 0;
    void Update()
    {
        if (DialogueManager.endDialogue == true)
        {
            SceneManager.LoadScene(2);
            b++;
            PlayerPrefs.SetInt("Clicks", b);
        }
    }
}
