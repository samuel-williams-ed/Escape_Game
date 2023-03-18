using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnObject : MonoBehaviour
{
    private GameObject objectToFocusOn;
    private Dictionary<string, Vector3> playerEndPositions = new Dictionary<string, Vector3>() {
        {"ExitDoor", new Vector3(-1.87f, 0.9f, 4f)},
        {"Radio", new Vector3(-3.75f, 0.9f, -3.5f)},
        {"PictureColour", new Vector3(-4f, 1.2f, 2.7f)},
        {"Desk", new Vector3(-3f, 1.6f, 2.8f)},
        {"ChestOfDrawers", new Vector3(1f, 1.9f, 2.8f)}
    };


    private void OnMouseDown() {
        if (gameObject.name == "ChestOfDrawers") {
            objectToFocusOn = transform.Find("ChestOfDrawersFocus").gameObject;
        } else if (gameObject.name == "ExitDoor") {
            objectToFocusOn = transform.Find("ExitDoorFocus").gameObject;
        } else {
            objectToFocusOn = gameObject;
        }

        Vector3 playerEndPosition = playerEndPositions[gameObject.name];
        PlayerMove.manager.FocusPlayer(objectToFocusOn, playerEndPosition);
    }

}

