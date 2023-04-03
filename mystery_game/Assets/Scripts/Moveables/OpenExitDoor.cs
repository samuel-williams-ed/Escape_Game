using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenExitDoor : MonoBehaviour
{
    private Quaternion doorStartRotation;
    private Quaternion doorEndRotation;
    private float timeElapsed;
    private bool doorOpening = false;
    private List<string> exitDoorLockedText = new List<string>() {
        "It's locked but there must be a key for it around here somewhere!"
    };
    private List<string> exitDoorUnlockedText = new List<string>() {
        "*CLICK*",
        "Now to figure out where I am and why...."
    };


    private void OnMouseDown() {
        if ( gameObject.tag == PlayerInventory.manager.getInventoryCurrentlySelected() ) {
            doorStartRotation = transform.rotation;
            doorEndRotation = Quaternion.FromToRotation(Vector3.forward, Vector3.right * 0.5f);
            doorOpening = true;
            ScenesManager.manager.EndGame();
        } else {
            GameManager.manager.UpdateDialogue(exitDoorLockedText);
        }
    }

    // Update is called once per frame
    void Update() {
        if (doorOpening) {
            if (timeElapsed < 1) {
                transform.rotation = Quaternion.Slerp(doorStartRotation, doorEndRotation, timeElapsed);
                timeElapsed += Time.deltaTime;
            } else {
                doorOpening = false;
                GameManager.manager.UpdateDialogue(exitDoorUnlockedText);
            }
        }
    }
}