using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitDoor : MonoBehaviour
{
    private Quaternion doorStartRotation;
    private Quaternion doorEndRotation;
    private float timeElapsed;
    private bool doorOpening = false;
    private bool exitDoorOpen = false;  // Add to game manager??

    private void OnMouseDown() {
        if (!exitDoorOpen) {
            doorStartRotation = transform.rotation;
            doorEndRotation = Quaternion.FromToRotation(Vector3.forward, Vector3.right * 0.5f);
            doorOpening = true;
        }    
    }

    // Update is called once per frame
    void Update() {
        if (doorOpening) {
            if (timeElapsed < 1) {
                transform.rotation = Quaternion.Slerp(doorStartRotation, doorEndRotation, timeElapsed);
                // transform.position = Vector3.Lerp(drawerStartPosition, drawerEndPosition, timeElapsed);
                timeElapsed += Time.deltaTime;
            } else {
                doorOpening = false;
            }
        }
    }
}
