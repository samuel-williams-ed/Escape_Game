using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorBook_ShowOrHide : MonoBehaviour
{
    void Start() {

        if (PlayerInventory.manager.hasFoundAuthorBook){

            gameObject.SetActive(false);
            Debug.Log("AgathaBook deactivated");
            
        } else {
            gameObject.SetActive(true);
            // Debug.Log("AgathaBook is active");
        }
    }

}
