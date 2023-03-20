using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    void Start() {
        if ( PlayerInventory.manager.askIfSecretDoorOpened() ){
            Debug.Log("Secret door has been opened!");
            // gameObject.transform.rotation = new Quaternion(0f, -90f, 0f, 0f);
            gameObject.transform.Rotate(0, 90, 0);
            gameObject.transform.position = new Vector3(1.01f, 0.085f, -3.678f);
            // original position is (0.458f, 0.085f, -3.11f)
        }
    }

}
