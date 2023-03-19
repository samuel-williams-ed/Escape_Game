using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey_ShowOrHide : MonoBehaviour
{
    void Start() {

        if (PlayerInventory.manager.hasRedKey){

            gameObject.SetActive(false);
            Debug.Log("RedKey deactivated");
            
        } else {
            gameObject.SetActive(true);
            Debug.Log("RedKey is active");
        }
    }

}

