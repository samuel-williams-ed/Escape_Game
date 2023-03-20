using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    void Start() {
        if ( PlayerInventory.manager.askIfSecretDoorOpened() ){
            
            gameObject.transform.rotation = new Quaternion(0f, -90f, 0f, 0f);
            gameObject.transform.position.x = 
        }
}

}
