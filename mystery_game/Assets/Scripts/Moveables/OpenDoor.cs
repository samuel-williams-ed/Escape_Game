using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject secret_door;

    // called from door lock

    // if manager declares door ready

    // receive door object

    // set new coordinates

    void OnMouseDown()
    {
        Debug.Log("MouseDown on lock - running tryToOpenTheDoor() on " + secret_door.name);
        tryToOpenTheDoor(secret_door);
    }

    public void tryToOpenTheDoor(GameObject secret_door){
        if (PlayerInventory.manager.askIfSecretDoorOpened()){
            secret_door.transform.Rotate(0, 90, 0);
            secret_door.transform.position = new Vector3(1.01f, 0.085f, -3.678f);
            Debug.Log("Door Opened!");
        }
    }

}
