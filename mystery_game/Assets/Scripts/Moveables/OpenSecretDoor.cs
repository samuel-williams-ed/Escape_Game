using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecretDoor : MonoBehaviour
{

    void Start() {
        if (PlayerInventory.manager.getIfSecretDoorOpened() ){            
            gameObject.transform.Rotate(0, 270, 0);
            gameObject.transform.position = new Vector3(1f, 0.085f, -3.7f);
        }
    }

}
