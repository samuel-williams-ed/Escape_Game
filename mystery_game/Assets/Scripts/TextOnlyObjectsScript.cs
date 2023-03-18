using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnlyObjectsScript : MonoBehaviour

{
    private List<string> bathroomDoorText = new List<string>();
    private List<string> radioText = new List<string>();
    private Dictionary <string, List<string>> dialogueDictionary;

    void Awake() {

        bathroomDoorText.Add("It doesn't look like I need to go in here");
        string radio1 = " '...This is the Erebus calling the Moby Dick. Can you hear me? Come in Moby Dick...' ";
        string radio2 = "It sounds like I'm picking up a message from a ship";
        radioText.Add(radio1);
        radioText.Add(radio2);
    
        dialogueDictionary = new Dictionary<string, List<string>>() {
            {"BathroomDoor", bathroomDoorText},
            {"Radio", radioText}
        };
    }

    private void OnMouseDown() {
        GameManager.manager.UpdateDialogue(dialogueDictionary[gameObject.name]);
    }

}


