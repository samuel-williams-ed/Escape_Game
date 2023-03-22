using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AuthorNoteClue : MonoBehaviour
{
    void OnMouseDown(){
        PlayerInventory.manager.hasFoundAuthor = true;
        Debug.Log("Found Author");
    }
}
