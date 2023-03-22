using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {
    public static PlayerMove manager;
    public GameObject reticle;  // Assigned in heirarchy
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

    public void setReticleStatus(bool trueFalse) {
        reticle.SetActive(trueFalse);
    }

    public void FocusPlayer(GameObject objectToFocusOn, Vector3 playerEndPosition) {
        StartCoroutine(Focus(objectToFocusOn, playerEndPosition));
    }

    private IEnumerator Focus(GameObject objectToFocusOn, Vector3 playerEndPosition) {
        // Remove player controls:
        PlayerMove.manager.setPlayerMoveable(false);
        PlayerLook.manager.setPlayerCanMoveCamera(false);
        setReticleStatus(false);

        // Get start position for player:
        Vector3 playerStartPosition = transform.position;

        // Following moves player over time period of 1 second:
        float timeElapsed = 0;
        while (timeElapsed < 1) {
            // Moves position of player object:
            transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, timeElapsed);
            // Focuses player object rotation to look at object to be focused on:
            transform.LookAt(objectToFocusOn.transform);
            // Focuses camera object rotation to look at object to be focused on:
            Camera.main.transform.LookAt(objectToFocusOn.transform);
            // Update timeElapsed variable:
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Load the required scene:
        string sceneName = ScenesManager.manager.scenes[objectToFocusOn.name];
        ScenesManager.manager.LoadScene(sceneName);
    }

    public void StepBackPlayer () {
        StartCoroutine(StepBack());
    }

    private IEnumerator StepBack() {
        // Load the required scene:
        ScenesManager.manager.LoadMainRoom();

        // Set end position for player:
        Vector3 playerEndPosition = new Vector3(transform.position.x - transform.forward.x, 1f, transform.position.z - transform.forward.z);

        float timeElapsed = 0;
        while (timeElapsed < 1) {
            transform.position = Vector3.Lerp(transform.position, playerEndPosition, timeElapsed);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            Camera.main.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Turn player controls back on:
        setReticleStatus(true);
        PlayerMove.manager.setPlayerMoveable(true); 
        PlayerLook.manager.setPlayerCanMoveCamera(true);
    }


}