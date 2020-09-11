using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Press buttons scripts: replay, exit
/// </summary>
public class ButtonsUtils : MonoBehaviour
{
    public void TryAgain()
    {
        if (SceneManager.GetActiveScene().name != "MainPage")
            PlayerMenu.audioBegin = false;
        SceneManager.LoadScene("FormGame");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
