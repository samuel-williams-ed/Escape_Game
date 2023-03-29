using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCloseLetters : MonoBehaviour

{ 
    private GameObject altLetter; 
    
    public void OnMouseDown() {
        if (gameObject.tag == "Letter") {
            altLetter = transform.Find("LetterCloseUp").gameObject;
            altLetter.SetActive(true);
        } else if (gameObject.tag == "LetterClose") {
            gameObject.SetActive(false);
        }
    } 

}









