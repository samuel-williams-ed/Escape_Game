using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnSecretDoor : MonoBehaviour
{
    private GameObject player;
    private GameObject leftDoor;
    private Quaternion leftDoorEndRotation;
    private GameObject rightDoor;
    private Quaternion rightDoorEndRotation;

    void Awake() {
        player = GameObject.Find("Player");
        if (gameObject.name == "SecretBookcaseGroup" && !GameManager.manager.getBookcaseUnlocked()) {
            leftDoor = transform.Find("TopLeftDoor").gameObject;
            rightDoor = transform.Find("TopRightDoor").gameObject;
            leftDoorEndRotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(1f, 0f, -1f));
            rightDoorEndRotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(-1f, 0f, -1f));
        }
    }

    private void OnMouseDown() {
        GameObject objectToFocusOn = GameObject.Find("SecretDoorFocus").gameObject;
        // Vector3 playerEndPosition = new Vector3(0.4f, 1f, -1.3f);
        Vector3 playerEndPosition = new Vector3(0.4f, 1f, -1.75f);
        StartCoroutine(Focus(objectToFocusOn, playerEndPosition));
    }

    private IEnumerator Focus(GameObject objectToFocusOn, Vector3 playerEndPosition) {
        // Remove player controls:
        PlayerMove.manager.setPlayerMoveable(false);
        PlayerLook.manager.setPlayerCanMoveCamera(false);
        PlayerMove.manager.setReticleStatus(false);

        // Following moves player over time period of 1 second:
        float timeElapsed = 0;
        while (timeElapsed < 1) {
            // Move & rotate player:
            player.transform.position = Vector3.Lerp(player.transform.position, playerEndPosition, timeElapsed);
            player.transform.LookAt(objectToFocusOn.transform);
            Camera.main.transform.LookAt(objectToFocusOn.transform);

            if (gameObject.name == "SecretBookcaseGroup" && !GameManager.manager.getBookcaseUnlocked()) {
                // Rotate bookcase doors:
                leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, leftDoorEndRotation, timeElapsed);
                rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, rightDoorEndRotation, timeElapsed);
            }

            // Update timeElapsed variable:
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Load the required scene:
        ScenesManager.manager.LoadScene("SecretDoor");
    }

}
