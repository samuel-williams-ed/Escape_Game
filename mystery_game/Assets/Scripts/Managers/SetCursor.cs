using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D pointer;

    void Start() {
        Vector3 cursorPosition = new Vector3(0, 0, 0);
        Cursor.SetCursor(pointer, cursorPosition, CursorMode.Auto);
    }
}
