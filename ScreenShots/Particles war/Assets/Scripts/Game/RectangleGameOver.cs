using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RectangleGameOver : MonoBehaviour
{
	Vector2				mousePosition;
	int					check;
	public Texture2D	cursorImage;

	private void Start()
	{
		check = 1;
	}
	void Update()
	{
		if (check == 1)
		{
			float distance;
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			distance = Vector3.Distance(mousePosition, transform.position);
			if (distance < 1.1f && Initialize.roundText.enabled == false)
			{
				PlayerPrefs.SetInt("Round", 1);
				GameObject music = GameObject.FindGameObjectWithTag("Music").gameObject;
				if (music)
					Destroy(music);
				SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
			}
			if (ParticleController.count == PlayerPrefs.GetInt("RoundAdd"))
			{
				#if UNITY_WEBGL
					float xspot = cursorImage.width / 4;
					float yspot = cursorImage.height / 4;
					Vector2 hotSpot = new Vector2(xspot, yspot);
					Cursor.SetCursor(cursorImage, hotSpot, CursorMode.ForceSoftware);
				#else
					Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
				#endif
				PlayerPrefs.SetInt("Round", PlayerPrefs.GetInt("Round") + 1);
				if (PlayerPrefs.GetInt("Round") > 5)
				{
					GameObject music = GameObject.FindGameObjectWithTag("Music").gameObject;
					if (music)
						Destroy(music);
					SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
				}
				else
					GameObject.FindWithTag("Next").GetComponent<Canvas>().enabled = true;
				this.check = 0;
			}
		}
	}
}
