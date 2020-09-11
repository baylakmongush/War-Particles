using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    /// <summary>
    /// Set cursor texture script
    /// </summary>
    public Texture2D cursorImage;
    void Start()
    {
        #if UNITY_WEBGL
                float xspot = cursorImage.width / 2;
                float yspot = cursorImage.height / 2;
                Vector2 hotSpot = new Vector2(xspot, yspot);
                Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
        #else
				Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
        #endif
    }
}
