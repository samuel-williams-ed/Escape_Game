using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    void Start() {
        if ( PlayerInventory.manager.askIfSecretDoorOpened() ){
            Debug.Log("Secret door has been opened!");
            
            gameObject.transform.Rotate(0, 90, 0);
            gameObject.transform.position = new Vector3(1.01f, 0.085f, -3.678f);
        }
    }

}
