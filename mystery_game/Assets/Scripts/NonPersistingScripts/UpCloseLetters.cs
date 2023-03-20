using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCloseLetters : MonoBehaviour

{ 
    
    public GameObject letter; 
    public GameObject closeupLetter; 
    
    public void OnMouseDown() {
        if (gameObject == letter) { 
            letter.SetActive(false); 
            closeupLetter.SetActive(true); 
            } else if (gameObject == closeupLetter) { 
                letter.SetActive(true); 
                closeupLetter.SetActive(false); 
            } 
        } 
}









