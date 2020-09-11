using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GetParam : MonoBehaviour
{
	InputField				getCount;					// inputfield of count of particles to create
	InputField				getNumberAdded;				// inputfield of number of added particles in next levels
	Text					errorMessage;				// error message
	int						gc;							// count of particles to create
	int						gn;                         // number of added particles in next levels

	/// <summary>
	/// initialised components method
	/// </summary>
	void Start()
	{
		getCount = GameObject.FindWithTag("CountPart").GetComponent<InputField>();
		getNumberAdded = GameObject.FindWithTag("NumberAdded").GetComponent<InputField>();
		errorMessage = GameObject.FindWithTag("ErrorText").GetComponent<Text>();
	}

	/// <summary>
	/// Get data from inputfields and save them to cache method
	/// </summary>

	public void GetData()
	{
		if (getCount.text != "" && getNumberAdded.text != "")
		{
			if (int.TryParse(getCount.text, out gc) && int.TryParse(getNumberAdded.text, out gn))	// check them, that they are numberss
			{
				if (gc > 0 && gn > 0 && gc <= 300 && gn <= 300)
				{
					PlayerPrefs.SetInt("CountPart", gc);
					PlayerPrefs.SetInt("NumberAdded", gn);
					PlayerPrefs.SetInt("Round", 1);
					PlayerPrefs.SetInt("RoundAdd", PlayerPrefs.GetInt("CountPart"));
					GameObject music = GameObject.FindGameObjectWithTag("MenuMusic").gameObject;
					if (music)
						Destroy(music);
					SoundPlayer.audioBegin = false;
					SceneManager.LoadScene("Game");
				}
				else if(gc > 300 || gn > 300)
					errorMessage.text = "Max value is 300!";
				else
					errorMessage.text = "Input a natural number!";
			}
			else
				errorMessage.text = "Input a natural number!";
		}
		else
			errorMessage.text = "Try again!";
	}
}
