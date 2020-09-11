using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// tab to next level with button class
/// </summary>
public class NextButton : MonoBehaviour
{
	public Texture2D cursorImage;
	public void  Next()
	{
		Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}
}
