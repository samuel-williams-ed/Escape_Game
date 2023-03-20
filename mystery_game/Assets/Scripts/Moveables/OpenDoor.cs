using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject secret_door;

    // this script is attached to the door locks
    // it receives the secret_door object as a parameter (assigned in heirarchy)
    // if inventory.manager declares door ready to be opened
    // set new coordinates & rotation of the door!

    void OnMouseDown() {
        tryToOpenTheDoor(secret_door);
    }

    public void tryToOpenTheDoor(GameObject secret_door){
        if (PlayerInventory.manager.askIfSecretDoorOpened()){
            secret_door.transform.Rotate(0, 90, 0);
            secret_door.transform.position = new Vector3(1.01f, 0.085f, -3.678f);

            // Debug.Log("Door Opened!");
            GameManager.manager.UpdateDialogue(new List<string>(){"The door opened...", "Look there's a secret room!"});
        }
    }

}
