using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnObject : MonoBehaviour
{
    private GameObject objectToFocusOn;
    private Dictionary<string, Vector3> playerEndPositions = new Dictionary<string, Vector3>() {
        {"ExitDoorFocus", new Vector3(-1.87f, 0.9f, 4f)},
        {"Radio", new Vector3(-3.75f, 0.9f, -3.5f)},
        {"PictureColour", new Vector3(-4f, 1.2f, 2.7f)},
        {"Desk", new Vector3(-3f, 1.6f, 2.8f)},
        {"ChestOfDrawersFocus", new Vector3(1f, 1.9f, 2.8f)},
        {"TopCrate", new Vector3(3.3f, 1.1f, -4.8f)},
        {"Padlock", new Vector3(2.8f, 0.45f, -7.5f)},
        {"SRChest", new Vector3(2.8f, 1.4f, -7.5f)}
    };

    private void OnMouseDown() {
        if (gameObject.name == "ChestOfDrawers") {
            objectToFocusOn = transform.Find("ChestOfDrawersFocus").gameObject;
        } else if (gameObject.name == "ExitDoor") {
            objectToFocusOn = transform.Find("ExitDoorFocus").gameObject;
        } else if (gameObject.name == "SRChest" && !GameManager.manager.getPadlockUnlocked()) {
            objectToFocusOn = GameObject.Find("Padlock").gameObject;
        } else if (gameObject.name == "Padlock" && GameManager.manager.getPadlockUnlocked()) {
            objectToFocusOn = transform.Find("SRChest").gameObject;
        } else {
            objectToFocusOn = gameObject;
        }

        Debug.Log(objectToFocusOn.name);

        Vector3 playerEndPosition = playerEndPositions[objectToFocusOn.name];
        PlayerMove.manager.FocusPlayer(objectToFocusOn, playerEndPosition);
    }

}

