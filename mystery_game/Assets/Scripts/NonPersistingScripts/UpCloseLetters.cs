using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCloseLetters : MonoBehaviour

{ 
    public GameObject altLetter; 
    private bool hideLetter = false;
    
    public void OnMouseDown() {
        if (gameObject.tag == "Letter") {
            altLetter = transform.Find("AuthorNoteCloseUp").gameObject;
            altLetter.SetActive(true);
        } else if (gameObject.tag == "LetterClose") {
            gameObject.SetActive(false);
        }
    } 

}








