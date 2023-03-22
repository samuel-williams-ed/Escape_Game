using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public static PlayerLook manager;
    [SerializeField] private string mouseXInputName = "Mouse X";
    [SerializeField] private string mouseYInputName = "Mouse Y";
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private Transform playerBody;
    private float xAxisClamp;
    private float xAxisUpperLimit = 20f;
    private float xAxisLowerLimit = -45f;
    private bool m_cursorIsLocked = true;
    private bool playerCanMoveCamera = false;

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

        xAxisClamp = 0.0f;
    }

    private void LockCursor() {
    
        if (Input.GetKeyUp(KeyCode.Escape)){
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0)){
            m_cursorIsLocked = true;
        }
        if (m_cursorIsLocked){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    private void Update() {
        // when player roaming can look around and mouse is stuck to reticle
        if (playerCanMoveCamera){
            LockCursor();
            CameraRotation();
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void CameraRotation() {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        // Set upper and lower limits on camera rotation around the x-axis:
        xAxisClamp += mouseY;
        if (xAxisClamp > xAxisUpperLimit) {
            xAxisClamp = xAxisUpperLimit;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(360f - xAxisUpperLimit);
        } else if (xAxisClamp < xAxisLowerLimit) {
            xAxisClamp = xAxisLowerLimit;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(-xAxisLowerLimit);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public void setPlayerCanMoveCamera(bool true_or_false){
        playerCanMoveCamera = true_or_false;
    }
    public bool getPlayerCanMoveCamera(){
        return playerCanMoveCamera;
    }
}
