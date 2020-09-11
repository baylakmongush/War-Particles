using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Play music in scene game without destroy
/// </summary>
public class SoundPlayer : MonoBehaviour
{
    public AudioSource  audioSource;
    public static bool audioBegin;
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
        if (SceneManager.GetActiveScene().name != "Game")
        {
            audioSource.Stop();
            audioBegin = false;
        }
    }
}
