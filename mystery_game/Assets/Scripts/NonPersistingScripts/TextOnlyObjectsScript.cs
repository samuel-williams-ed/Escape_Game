using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnlyObjectsScript : MonoBehaviour

{
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

        List<string> drawersBookText = new List<string>();
        drawersBookText.Add("This doesn't look useful");

        List<string> drawersCandleText = new List<string>();
        drawersCandleText.Add("This is just a candle");

        List<string> drawersCutleryText = new List<string>();
        drawersCutleryText.Add("What a load of old junk");

        List<string> drawersBinocularsText = new List<string>();
        drawersBinocularsText.Add("I wonder who these belong too?");

        List<string> drawersDuckText = new List<string>();
        drawersDuckText.Add(" 'QUACK!!' ");

        List<string> drawersChessText = new List<string>();
        drawersChessText.Add("Nothing useful in this drawer");

        List<string> drawersHornText = new List<string>();
        drawersHornText.Add("Woah, an antique drinking horn!");

        List<string> drawersCoffeeText = new List<string>();
        drawersCoffeeText.Add("They have a coffee grinder... I wonder if they have coffee here too?");
        
        List<string> drawersRedKeyCollection = new List<string>();
        drawersRedKeyCollection.Add("I better keep hold of this, this will be useful");

        List<string> greenKeyText = new List<string>(){"Oh, well look at that!", "...someone wanted to keep this hidden"};
        List<string> blueKeyText = new List<string>(){"This looks old but well used, might be useful."};

        List<string> teamPictureText = new List<string>();
        string teamPicture1 = "mmh... this portrait reminds me of someone..";
        string teamPicture2 = "Oh! I know. Captain Hook.";
        teamPictureText.Add(teamPicture1);
        teamPictureText.Add(teamPicture2);

        List<string> authorBookText = new List<string>(){"Aha!", "This must be the book Agatha Christe gifted the owner of that note...", "And look at whats behind... an Agatha Christ-key you might say..."};
        List<string> titleBookText = new List<string>(){"Moby Dick eh... looks like I found my white whale."};
        List<string> decoyBook1Text = new List<string>(){"The cover of this is really ornate,", "Judging by the dust on top it hasn't been used for many years..."};
        List<string> decoyBook2Text = new List<string>(){"This book has a really cool cover.", "Someone must have spent ages making this."};
        // List<string> leverBookText = new List<string>(){"This book won't budge!"};

        // Key = object name, Value = list name
        dialogueDictionary = new Dictionary<string, List<string>>() {
            {"BathroomDoor", bathroomDoorText},
            {"Radio", radioText},
            {"PictureColour", pictureColourText}, 
            {"CODBook", drawersBookText},
            {"CODCandle", drawersCandleText},
            {"CODCutlery", drawersCutleryText},
            {"CODBinoculars", drawersBinocularsText},
            {"CODDuck", drawersDuckText},
            {"CODChessPieces", drawersChessText},
            {"CODHorn", drawersHornText},
            {"CODCoffee", drawersCoffeeText},
            {"RedKey", drawersRedKeyCollection},
            {"BlueKey", blueKeyText},
            {"GreenKey", greenKeyText},
            {"TeamPicture", teamPictureText},
            {"AgathaBook", authorBookText},
            {"MobyBook", titleBookText},
            {"DecoyBook1", decoyBook1Text},
            {"DecoyBook2", decoyBook2Text},

        };
    }

    private void OnMouseDown() {
        GameManager.manager.UpdateDialogue(dialogueDictionary[gameObject.name]);
    }

}

