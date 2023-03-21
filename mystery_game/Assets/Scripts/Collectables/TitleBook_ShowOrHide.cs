using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBook_ShowOrHide : MonoBehaviour
{
    void Start() {

        if (PlayerInventory.manager.hasFoundTitleBook){

            gameObject.SetActive(false);
            Debug.Log("MobyBook deactivated");
            
        } else {
            gameObject.SetActive(true);
            // Debug.Log("MobyBook is active");
        }
    }

}
