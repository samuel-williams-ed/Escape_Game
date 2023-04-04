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
        bathroomDoorText.Add("Which is good, because it smells kinda fishy...");

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
        List<string> blueKeyText = new List<string>(){"Ahh a blue key!", "My seasoned instincts tell me this must unlock something!"};

        List<string> teamPictureText = new List<string>();
        string teamPicture1 = "Wow, these guys must really love themselves";
        string teamPicture2 = "Remnds me of Captain Hook";
        teamPictureText.Add(teamPicture1);
        teamPictureText.Add(teamPicture2);

        List<string> authorBookText = new List<string>(){"Aha!", "This must be the book Agatha Christie gifted the owner of that note...", "And look at what's behind... an Agatha Christ-key you might say..."};
        List<string> titleBookText = new List<string>(){"Moby Dick eh... looks like I found my white whale."};
        List<string> decoyBook1Text = new List<string>(){"The cover of this is really ornate,", "Judging by the dust on top it hasn't been used for many years..."};
        List<string> decoyBook2Text = new List<string>(){"This book has a really cool cover.", "Someone must have spent ages making this."};
        List<string> monsterClueText = new List<string>(){"I feel like I've seen this before somewhere..."};

        List<string> clockText = new List<string>(){"Oh, good! Time hasn't stopped..."};
        List<string> pictureByClock = new List<string>(){"I think I saw the same picture at the Sunday market..."};
        List<string> westWallCandle = new List<string>(){"There are so many lights in this house", "It's almost like it's a...", "Well, never mind"};
        List<string> candle = new List<string>(){"Who still uses candles?"};
        List<string> stool = new List<string>(){"I wonder why this place is so untidy?"};
        List<string> floorPlanks = new List<string>(){"These look like the planks that cover the windows",
        "My detective skills proving themselves again"};
        List<string> miniBoat = new List<string>(){"What a cute little boat"};
        List<string> boots = new List<string>(){"Ugh, they smell", "Look at those mouldy soles..."};
        List<string> windowPlanks = new List<string>(){"The windows are all boarded up", "Too dark to see anything outside"};
        List<string> coatHooks = new List<string>(){"Hang in there buddy... heheheh"};
        List<string> bearPicture = new List<string>(){"I think that's Louisiana, I can almost smell the salmon"};
        List<string> pot = new List<string>(){"Nothing inside"};
        List<string> shelf = new List<string>(){"Uh oh, looks like it's falling, I wouldn't get too close."};
        List<string> sofa = new List<string>(){"Uuugh, I wouldn't sit here, my butt deserves better treatment"};
        List<string> tiles = new List<string>(){"Wow, these tiles are hideous..."};
        List<string> nail = new List<string>(){"Yup, that's a nail - looks well crafted"};
        List<string> oldBucket = new List<string>(){"Ugh, these are all filthy... nothing inside anyway..."};
        List<string> pictureByRadio = new List<string>(){"Huh, another picture of the seaside"};
        List<string> wastePaperBasket = new List<string>(){"It's empty"};
        List<string> rug = new List<string>(){"What an ugly carpet", "Looks like it's caught on the floor board"};
        List<string> deskGlobe = new List<string>(){"The world is huge and full of possibilities!", "Good reminder globe, good reminder"};
        List<string> blackBiro = new List<string>(){"This is a pen"};
        List<string> blueBiro = new List<string>(){"A pen"};
        List<string> redBiro = new List<string>(){"Yup, pen here"};
        List<string> greenBiro = new List<string>(){"Is it a bird? Is it a plane?", "No. No, it's a 3D modelled object with green pen mesh renderer."};
        List<string> e62Note = new List<string>(){"e62? Charlotte... Indira... Louise... Sam... they all sound nice"};
        List<string> ashtray = new List<string>(){"This is very clean, looks like someone kicked their habit.", "Good job them"};
        List<string> SRtableCrate = new List<string>(){"Looks like this was a tasty drink... once..."};
        List<string> SRChair = new List<string>(){"Pretty, yes. Accessible, not with those anchors."};
        List<string> SRAnchor1 = new List<string>(){"Who keeps anchors in their house?"};
        List<string> SRAnchor2 = new List<string>(){"Clunky"};
        List<string> SRCandle = new List<string>(){"..."};
        List<string> SRCandleSarcastic = new List<string>(){"I feel illuminated"};
        List<string> SRCandlePositive = new List<string>(){"My mood feels brightened!"};
        List<string> SRCrateBottom = new List<string>(){"These are heavy but I might be able to move one"};
        List<string> SRBigBook = new List<string>(){"Looks old, chunky, wish I had time to read it all"};
        List<string> SRMiniChest = new List<string>(){"A numismatist would love these"};
        List<string> SRWindow = new List<string>(){"I can see out a little", "Can't really make anything out..."};
        List<string> EscapeKey = new List<string>(){"This is a big old rusty key! I wonder what lock it fits..."};
        List<string> lockedDrawerText = new List<string>() {"Hmm won't budge. There must be some way to open it..."};

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
            {"MonsterClue", monsterClueText},
            {"clock", clockText},
            {"PictureByFireplace", pictureByClock},
            
            {"candleFireplace", candle},
            {"northWallCandle", SRCandle},
            {"stool", stool},
            {"FloorPlanks", floorPlanks},
            {"boat_1", miniBoat},
            {"boots", boots},
            {"northWindow", windowPlanks},
            {"hanger", coatHooks},
            {"floorPictures", bearPicture},

            {"SpiceBox_1", pot},
            {"Shelf1", shelf},
            {"DoubleSeat2", sofa},
            // {"", tiles},
            // {"", nail},
            {"RandomDecors", oldBucket},
            {"westWindow", windowPlanks},
            {"Paint_07", pictureByRadio},
            {"WastePaperBasket", wastePaperBasket},
            
            // {"", rug},
            {"westWallCandle", westWallCandle},
            {"Globe", deskGlobe},
            {"Pen black", blackBiro},
            {"Pen blue", blueBiro},
            {"Pen red", redBiro},
            {"Pen green", greenBiro},
            {"NoteE62", e62Note},
            {"Ashtray", ashtray},

            {"CrateTable", SRtableCrate},
            {"SRChair", SRChair},
            {"SRAnchor1", SRAnchor1},
            {"SRAnchor2", SRAnchor2},
            // {"", SRCandle},
            // {"", SRCandleSarcastic},
            // {"", SRCandlePositive},
            {"BottomRightCrate", SRCrateBottom},
            {"BottomLeftCrate", SRCrateBottom},
            {"SRBigBook", SRBigBook},
            {"SRMiniChest", SRMiniChest},
            {"SRWindowPlanks", SRWindow},
            {"EscapeKey", EscapeKey},
            {"TopDrawer2", lockedDrawerText}
        };
    }

    private void OnMouseDown() {
        if (gameObject.name == "TopDrawer2") {
            if (!GameManager.manager.getSecretDrawerUnlocked()) {
                GameManager.manager.UpdateDialogue(dialogueDictionary[gameObject.name]);
            }
        } else {
            GameManager.manager.UpdateDialogue(dialogueDictionary[gameObject.name]);
        }
    }

}

