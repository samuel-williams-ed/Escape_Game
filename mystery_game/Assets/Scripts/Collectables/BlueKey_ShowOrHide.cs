using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey_ShowOrHide : MonoBehaviour
{
    void Start() {

        if (PlayerInventory.manager.hasBlueKey){

            gameObject.SetActive(false);
            Debug.Log("BlueKey deactivated");
            
        } else {
            gameObject.SetActive(true);
            Debug.Log("BlueKey is active");
        }
    }

}
