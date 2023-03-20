using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKey_ShowOrHide : MonoBehaviour
{
    void Start() {

        if (PlayerInventory.manager.hasGreenKey){

            gameObject.SetActive(false);
            Debug.Log("GreenKey deactivated");
            
        } else {
            gameObject.SetActive(true);
            Debug.Log("GreenKey is active");
        }
    }

}
