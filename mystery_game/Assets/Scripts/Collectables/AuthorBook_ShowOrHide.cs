using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorBook_ShowOrHide : MonoBehaviour
{
    void Start() {

        // persist if book is hidden
        if (PlayerInventory.manager.hasFoundAuthorBook){

            gameObject.SetActive(false);
            Debug.Log("AgathaBook found! (and deactivated)");
            
        } else {
            gameObject.SetActive(true);
            // Debug.Log("AgathaBook is active");
        }
    }

    // 'addToInventory' will set booleans for having been found
    public void OnMouseDown() {
        if (PlayerInventory.manager.hasFoundAuthor){
            
            PlayerInventory.manager.addToInventory(this.gameObject);
            gameObject.SetActive(false);
            GameManager.manager.UpdateDialogue(new List<string>(){"This looks interesting..."});
        }

        GameManager.manager.UpdateDialogue(new List<string>(){"This looks interesting..."});

    }

}
