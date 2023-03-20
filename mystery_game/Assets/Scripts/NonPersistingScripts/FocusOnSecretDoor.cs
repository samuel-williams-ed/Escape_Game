using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnSecretDoor : MonoBehaviour
{
    private ScenesManager scenesManager;
    private GameObject player;
    private Vector3 playerStartPosition;
    private Quaternion playerStartRotation;
    private Vector3 playerEndPosition = new Vector3(0.4f, 1f, -1.3f);
    private Quaternion playerEndRotation;
    private GameObject leftDoor;
    private Quaternion leftDoorStartRotation;
    private GameObject rightDoor;
    private Quaternion rightDoorStartRotation;
    private float timeElapsed;
    private float lerpDuration = 3; // Total time the transition should last for
    private bool movingToBookcase = false;

    // Start is called before the first frame update
    void Start() {

        scenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
        player = GameObject.Find("Player");
        leftDoor = transform.Find("TopLeftDoor").gameObject; // Think about if attaching to actual cabinet door
        rightDoor = transform.Find("TopRightDoor").gameObject;
        leftDoorStartRotation = leftDoor.transform.rotation;
        rightDoorStartRotation = rightDoor.transform.rotation;
    }

    private void OnMouseDown() {
        PlayerMove.manager.setPlayerMoveable(false);
        PlayerLook.manager.setPlayerCanMoveCamera(false);

        playerStartPosition = player.transform.position;
        playerStartRotation = player.transform.rotation;
        playerEndRotation = scenesManager.FindPlayerEndRotation(transform.position, playerStartPosition);
        movingToBookcase = true;
    }

    // Update is called once per frame
    void Update() {
        if (movingToBookcase) {
            if (timeElapsed < lerpDuration) {
                float interpolationRatio = timeElapsed/lerpDuration;
                float rotationSpeed = timeElapsed/2;
                player.transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, interpolationRatio);
                player.transform.rotation = Quaternion.Slerp(playerStartRotation, playerEndRotation, rotationSpeed);
                leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, scenesManager.OpenLeftDoorEndRotation(), rotationSpeed);
                rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, scenesManager.OpenRightDoorEndRotation(), rotationSpeed);
                timeElapsed += Time.deltaTime;
            } else {
                movingToBookcase = false;
                scenesManager.LoadScene("SecretDoor");
            }
        }
    }
}
