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

        // 'addToInventory' will set boolean for 'hasFoundTitleBook'
    public void OnMouseDown() {
        if (PlayerInventory.manager.hasFoundTitle){
            
            PlayerInventory.manager.addToInventory(this.gameObject);
            gameObject.SetActive(false);

            GameManager.manager.UpdateDialogue(new List<string>(){
                "Moby Dick eh... looks like I found my white whale."
            });

        }

        GameManager.manager.UpdateDialogue(new List<string>(){"This looks interesting..."});

    }

}
