using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    private List<string> exitDoorWrongKey = new List<string>() {
        "This key doesn't fit..."
    };
    private List<string> exitDoorLockedText = new List<string>() {
        "It's locked but there must be a key for it around here somewhere!"
    };


    private void OnMouseDown() {
        if (PlayerInventory.manager.getInventoryCurrentlySelected() != "") {
            if (gameObject.tag == PlayerInventory.manager.getInventoryCurrentlySelected()) {
                ScenesManager.manager.EndGame();
            } else {
                GameManager.manager.UpdateDialogue(exitDoorWrongKey);
                PlayerInventory.manager.resetCurrentlySelected();
            }
        } else {
            GameManager.manager.UpdateDialogue(exitDoorLockedText);
        }
    }

}