using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCursor : MonoBehaviour
{
    public Texture2D pointerCursor; // Assign a pointer cursor texture in the Inspector

    private void OnMouseEnter()
    {
        Cursor.SetCursor(pointerCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Reset to the default cursor
    }
}