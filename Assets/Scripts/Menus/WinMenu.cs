using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("WaterSampleScene");
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");

        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Adiosito :3");
        Application.Quit();
    }
}
