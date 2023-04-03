using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecretDoor : MonoBehaviour {

    public GameObject secret_door; // it receives the secret_door object as a parameter (assigned in heirarchy)

    void OnMouseDown() {
        // Debug.Log("Lock tag = " + gameObject.tag + ", current key = " + PlayerInventory.manager.getInventoryCurrentlySelected());

        // If there is an item in the inventory selected, then:
        if (PlayerInventory.manager.getInventoryCurrentlySelected() != "") {

            // check currentlySelected Key is for this lock
            if (gameObject.tag == PlayerInventory.manager.getInventoryCurrentlySelected() ) {

                // set the boolean for lock status in PlayerInventory
                // remove item from inventory
                // remove item from GUI
                // check for all conditions to be true and update whether secret door is unlocked
                PlayerInventory.manager.OpenLock(gameObject.name);

                // actally open the door
                tryToOpenTheDoor(secret_door);

                // give player feedback 
                GameManager.manager.UpdateDialogue(new List<string>(){"The key worked!"});

            } else {
                GameManager.manager.UpdateDialogue(new List<string>(){"This key doesn't fit..."});
                PlayerInventory.manager.resetCurrentlySelected();
            }
        
        // Else, if no item in the inventory is selected then:
        } else {
            // If the lock is unlocked:
            if (PlayerInventory.manager.GetLockStatus(gameObject.name)) {
                GameManager.manager.UpdateDialogue(new List<string>(){"I've already unlocked this."});

            // Else, the lock is not unlocked:
            } else {
                GameManager.manager.UpdateDialogue(new List<string>(){"I need to find a key..."});
            }
        }

    }

    public void tryToOpenTheDoor(GameObject secret_door){
        Debug.Log("Trying to open door...");
        
        // check ready to be opened
        if (PlayerInventory.manager.getIfSecretDoorOpened()){
            Debug.Log("Door position being changed " + PlayerInventory.manager.getIfSecretDoorOpened());

            // position door
            secret_door.transform.RotateAround(new Vector3(1f, 0.085f, -3.7f), Vector3.up, 270f);

            GameManager.manager.UpdateDialogue(new List<string>(){"The door opened...", "Look there's a secret room!"});

            // load back into main 'EscapeRoom' scene
            PlayerMove.manager.StepBackPlayer();
        }
    }
}

