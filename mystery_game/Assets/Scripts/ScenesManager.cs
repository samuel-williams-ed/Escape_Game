using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadScene() {
        SceneManager.LoadScene("SecretDoor");
        Debug.Log("Scene Loaded");
    }

     // Two returns deal with the player coming to the cabinet from different sides (finds the objects x position and the players x position and calculate the angle of rotation to do this)
    public Quaternion FindPlayerEndRotation(Vector3 objectPosition, Vector3 playerPosition) {
        if (objectPosition.x > playerPosition.x) {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
