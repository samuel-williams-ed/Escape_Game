using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnlyObjectsScript : MonoBehaviour

{
    // private List<string> bathroomDoorText = new List<string>();
    // private List<string> radioText = new List<string>();
    // private List<string> pictureColourText = new List<string>();
    private Dictionary <string, List<string>> dialogueDictionary;

    void Awake() {

        List<string> bathroomDoorText = new List<string>();
        bathroomDoorText.Add("It doesn't look like I need to go in here");

        List<string> radioText = new List<string>();
        string radio1 = " '...This is the Erebus calling the Moby Dick. Can you hear me? Come in Moby Dick...' ";
        string radio2 = "It sounds like I'm picking up a message from a ship";
        radioText.Add(radio1);
        radioText.Add(radio2);

        List<string> pictureColourText = new List<string>();
        string pictureColour1 = "Mmh... interesting sequence of colours...";
        string pictureColour2 = "It doesn't fit with the decor though, I wonder if it serves another purpose...";
        pictureColourText.Add(pictureColour1);
        pictureColourText.Add(pictureColour2);

        List<string> teamPictureText = new List<string>();
        string teamPicture1 = "mmh... this portrait reminds me of someone..";
        string teamPicture2 = "Oh! I know. Captain Hook.";
        teamPictureText.Add(teamPicture1);
        teamPictureText.Add(teamPicture2);

    
        dialogueDictionary = new Dictionary<string, List<string>>() {
            {"BathroomDoor", bathroomDoorText},
            {"Radio", radioText},
            {"PictureColour", pictureColourText},
            {"TeamPicture", teamPictureText}
        };

    }

    private void OnMouseDown() {
        GameManager.manager.UpdateDialogue(dialogueDictionary[gameObject.name]);
    }

}


