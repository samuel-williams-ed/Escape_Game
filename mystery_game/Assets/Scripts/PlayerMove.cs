using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {
    public static PlayerMove manager;
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float jumpSpeed = 0.0000003f;
    [SerializeField] private float gravity = -9.81f;
    private float yVelocity = 0f;
    private CharacterController charController;
    private bool playerMoveAllowed = false;

    private void Awake() {
        // make a singleton
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }

        charController = GetComponent<CharacterController>();
    }

    private void Update() {
        if (playerMoveAllowed) {
            PlayerMovement();
        }
    }

    private void PlayerMovement() {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        if (charController.isGrounded) { // Check if the character is on the ground
            if (Input.GetButtonDown("Jump")) { // Check if the jump button is pressed
                yVelocity = jumpSpeed; // Add jump speed to the yVelocity
            }
        } else {
            yVelocity += gravity * Time.deltaTime; // Apply gravity
        }

        Vector3 jumpMovement = Vector3.up * yVelocity; // Calculate jump movement
        Vector3 gravityMovement = Vector3.up * gravity * Time.deltaTime; // Calculate gravity movement

        charController.Move((forwardMovement + rightMovement + jumpMovement + gravityMovement) * Time.deltaTime);
    }

    // able / diable player movement setters & getters
    public void setPlayerMoveable(bool true_or_false){
        playerMoveAllowed = true_or_false;
    }
    public bool getIfPlayerMoveable(){
        return playerMoveAllowed;
    }

    public void FocusPlayer(Transform objectToFocusOn, Vector3 playerEndPosition, string sceneName) {
        StartCoroutine(Focus(objectToFocusOn, playerEndPosition, sceneName));
    }

    private IEnumerator Focus(Transform objectToFocusOn, Vector3 playerEndPosition, string sceneName) {
        // Remove player controls:
        PlayerMove.manager.setPlayerMoveable(false);
        PlayerLook.manager.setPlayerCanMoveCamera(false);

        // Get start position for player:
        Vector3 playerStartPosition = transform.position;

        // Following moves player over time period of 1 second:
        float timeElapsed = 0;
        while (timeElapsed < 1) {
            // Moves position of player object:
            transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, timeElapsed);
            // Focuses player object rotation to look at object to be focused on:
            transform.LookAt(objectToFocusOn);
            // Focuses camera object rotation to look at object to be focused on:
            Camera.main.transform.LookAt(objectToFocusOn);
            // Update timeElapsed variable:
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Load the required scene:
        ScenesManager.manager.LoadScene(sceneName);
    }

}