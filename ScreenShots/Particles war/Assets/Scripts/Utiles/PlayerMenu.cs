using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Play music in scene main page and formgame without destroy
/// </summary>
public class PlayerMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public static bool audioBegin = false;

    private void Awake()
    {
        if (!audioBegin)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            DontDestroyOnLoad(audioSource);
            audioBegin = true;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainPage" && SceneManager.GetActiveScene().name != "FormGame")
        {
            audioSource.Stop();
            audioBegin = false;
        }
    }
}
