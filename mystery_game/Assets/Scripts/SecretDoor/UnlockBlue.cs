using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBlue : MonoBehaviour {


public GameObject secret_door; // it receives the secret_door object as a parameter (assigned in heirarchy)

    void OnMouseDown() {
        Debug.Log("Lock tag = " + gameObject.tag + ", current key = " + PlayerInventory.manager.getInventoryCurrentlySelected());
        
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

            Debug.Log("Wrong key");
        }
    }

    public void tryToOpenTheDoor(GameObject secret_door){
        Debug.Log("Trying to open door...");
        
        // check ready to be opened
        if (PlayerInventory.manager.getIfSecretDoorOpened()){
            Debug.Log("Door position being changed " + PlayerInventory.manager.getIfSecretDoorOpened());

            // position door
            secret_door.transform.Rotate(0, 90, 0);
            secret_door.transform.position = new Vector3(1.01f, 0.085f, -3.678f);

            // Debug.Log("Door Opened!");
            GameManager.manager.UpdateDialogue(new List<string>(){"The door opened...", "Look there's a secret room!"});

            ScenesManager.manager.LoadMainRoom();
        }
    }
}

