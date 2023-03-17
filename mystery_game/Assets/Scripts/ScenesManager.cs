using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public ScenesManager manager;


    public Button backButton;
    private GameObject bookcase;

    //  make me a singlton
    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }


    }


    public void LoadScene() {
        SceneManager.LoadScene("SecretDoor");
        addBackButton();
    }


    public void LoadMainRoom(){
        SceneManager.LoadScene("EscapeRoom");
        removeBackButton();
        // bookcase = GameObject.Find("SecretBookcaseGroup").gameObject;
        PlayerMove.manager.setPlayerMoveable(true);
        PlayerLook.manager.setPlayerCanMoveCamera(true);
        // if(GameManager.manager.getBookcaseUnlocked()){
        //     bookcase.transform.position = GameManager.manager.bookcaseEndPosition;
        // }
    }

     // Two returns deal with the player coming to the cabinet from different sides (finds the objects x position and the players x position and calculate the angle of rotation to do this)
    public Quaternion FindPlayerEndRotation(Vector3 objectPosition, Vector3 playerPosition) {
        if (objectPosition.x >= playerPosition.x) {
            return Quaternion.FromToRotation(new Vector3(objectPosition.x, 0, 0), new Vector3(playerPosition.x, 0, 0));
        } else {
            return Quaternion.FromToRotation(new Vector3(objectPosition.x, 0, 0), new Vector3(-playerPosition.x, 0, 0));
        }
    }

    public Quaternion OpenLeftDoorEndRotation() {
        return Quaternion.FromToRotation(Vector3.forward, Vector3.right);
    }

    public Quaternion OpenRightDoorEndRotation() {
        return Quaternion.FromToRotation(Vector3.forward, Vector3.left);
    }

    // add/remove button when changing scenes
    public void addBackButton(){
        backButton.gameObject.SetActive(true);
    }
    public void removeBackButton(){
        backButton.gameObject.SetActive(false);
    }
}
