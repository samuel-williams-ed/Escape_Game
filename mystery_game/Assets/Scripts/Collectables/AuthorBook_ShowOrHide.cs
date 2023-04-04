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

    // 'addToInventory' will set boolean for 'hasFoundAuthorBook'
    public void OnMouseDown() {
        if (PlayerInventory.manager.hasFoundAuthor){
            
            PlayerInventory.manager.addToInventory(this.gameObject);
            gameObject.SetActive(false);
            GameManager.manager.UpdateDialogue(new List<string>(){
                "Aha! This must be the book Agatha Christie gifted the owner of that note...", 
                "And look at what's behind... an Agatha Christ-key you might say..."
            });

        }

        GameManager.manager.UpdateDialogue(new List<string>(){"This looks interesting..."});

    }

}
