using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Initialize : MonoBehaviour
{
	public static Text			roundText;
	Vector2						position;
	GameObject					ball;
	public GameObject			prefabBall;
	SpriteRenderer				spriteBall;
	public Sprite[]				newSpriteBall;
	public Texture2D			cursorImage;
	float						size;

	/// <summary>
	/// Initialize variables
	/// </summary>

	void Start()
	{
		roundText = GameObject.FindWithTag("Round").GetComponent<Text>();
		StartCoroutine(ShowMessage("Round", PlayerPrefs.GetInt("Round"), 2));									// delay in 2 seconds
		StartCoroutine(DelayAfter(2));
		if (PlayerPrefs.GetInt("Round") > 1)
			PlayerPrefs.SetInt("RoundAdd", PlayerPrefs.GetInt("RoundAdd") + PlayerPrefs.GetInt("NumberAdded")); // set added particles in next level
		#if UNITY_WEBGL
				float xspot = cursorImage.width / 2;
				float yspot = cursorImage.height / 2;
				Vector2 hotSpot = new Vector2(xspot, yspot);
				Cursor.SetCursor(cursorImage, hotSpot, CursorMode.ForceSoftware);
		#else
				Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
		#endif
	}

	/// <summary>
	/// Functions for delay in start
	/// </summary>
	/// <param name="message"></param>
	/// <param name="count"></param>
	/// <param name="delay"></param>
	/// <returns></returns>
	IEnumerator ShowMessage(string message, int count, float delay)
	{
		roundText.text = message + " " + Convert.ToString(count);
		roundText.enabled = true;
		yield return new WaitForSeconds(delay);
		roundText.enabled = false;
	}

	IEnumerator DelayAfter(float delay)
	{
		while (roundText.enabled == true)
			yield return new WaitForSeconds(delay);
		for (int i = 0; i < PlayerPrefs.GetInt("RoundAdd"); i++) // create particles
		{
			position = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(-1, 2), Random.Range(-1, 2))); // create in random positions
			ball = Instantiate(prefabBall, position, Quaternion.identity);
			spriteBall = ball.GetComponent<SpriteRenderer>();
			spriteBall.sprite = newSpriteBall[Random.Range(0, 3)];												// create with random sprites
			size = Random.Range(0.08f, 0.02f);																	// create with random size
			ball.transform.localScale = new Vector3(size, size, size);
		}
		ParticleController.count = 0;																					// count score initialize in ParticleController class
	}
}
