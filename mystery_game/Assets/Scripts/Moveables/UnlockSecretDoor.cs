using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecretDoor : MonoBehaviour {

    // public GameObject player;

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

            // Rotate lock to show it's open:
            gameObject.transform.Rotate(new Vector3(0f, 0f, 0f));

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
            secret_door.transform.RotateAround(new Vector3(1f, 0.085f, -3.7f), Vector3.up, 270f);

            GameManager.manager.UpdateDialogue(new List<string>(){"The door opened...", "Look there's a secret room!"});

            // load back into main 'EscapeRoom' scene
            PlayerMove.manager.StepBackPlayer();

            // StartCoroutine(reorientatePlayer());
        }
    }


    // private IEnumerator reorientatePlayer() {

    //         // player = GameManager.manager.getPlayer();
    //         // player.transform.localRotation = new Quaternion(0f, 176f, 0f, 0f);

    //         // ScenesManager.manager.LoadMainRoom();
    //         // PlayerMove.manager.setPlayerMoveable(true);
    //         // PlayerLook.manager.setPlayerCanMoveCamera(true);

    //     player = GameManager.manager.getPlayer();
            
    //         // get current player position & orientation
    //         Vector3 currentPosition;
    //         Quaternion currentRotation;
    //         player.transform.GetLocalPositionAndRotation(out currentPosition, out currentRotation);

    //         // reset orientation - keep position
    //         //player.transform.SetLocalPositionAndRotation(currentPosition, new Quaternion(0f,175f,0f,0f));

    //     // Following moves player over time period of 1 second:
    //     float timeElapsed = 0;
    //     while (timeElapsed < 1) {

    //         // Move & rotate player:
    //         player.transform.localPosition = Vector3.Lerp(currentPosition, currentPosition, timeElapsed);
    //         player.transform.localRotation = Quaternion.Slerp(currentRotation, new Quaternion(0, 0, 0, 0), timeElapsed);
            
    //         // reset camera orientation - may not be neccesary
    //         // Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0f, 0.5f, 0f), new Quaternion(0, 0, 0, 0));

    //         // Update timeElapsed variable:
    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }
    // }
}

