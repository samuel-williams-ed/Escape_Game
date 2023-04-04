using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net.Http;

public class PlayerInventory : MonoBehaviour
{
    // #####
    // ##### properties for recording inventory and displaying to GUI 
    // #####

    public static PlayerInventory manager;
    public Button s1;
    public Button s2;
    public Button s3;
    public Button s4;
    public TextMeshProUGUI slot1;
    public TextMeshProUGUI slot2;
    public TextMeshProUGUI slot3;
    public TextMeshProUGUI slot4; 
    public Sprite BlueKeyImg;
    public Sprite GreenKeyImg;
    public Sprite RedKeyImg;
    public Sprite EscapeKeyImg; 

    private string[] allItems; // should be name (string) of each item as GameObjects won't persist across scenes!
    
    // dictionary 'key' (from KeyGUIName) associated with inventory GUI item selected
    private string inventoryCurrentlySelected = "";

    // #####
    // ##### conditional properties for recording current game state 
    // #####

    public bool deskDrawerUnlocked = false; // contains blue key
    public bool hasFoundAuthor = false; // Agatha Christie clue found (green key) on note on desk (MVP) or inside desk drawer (Ext) 
    public bool hasFoundTitle = false; // Finds clue for Moby Dick by listening to radio
    public bool hasFoundMonster = false; // can only click monster book (& open bookcase) once monster found


    public bool hasFoundAuthorBook = false; // reveals green key behind the book
    public bool hasFoundTitleBook = false; // feedback to player: "I could swear I heard a click - like a break being released..."
    public bool canOpenBookcase = true; //can only open bookcase after ^two books are found
// TODO - make private (public for testing)

    public bool hasRedKey = false;  // in chest of drawers
    public bool hasGreenKey = false; // behind Agatha Christie (Christkey?) book
    public bool hasBlueKey = false; // in desk drawer - needs to be unlocked by scales
    private bool hasAllKeys = false; // allows player to try to open secret door locks
    public bool hasEscapeKey = false; // allows player to exit final door
    
    public Dictionary<string, string> KeyGUIText = new Dictionary<string, string>(){
        {"RedKey", "A red key"},
        {"GreenKey", "A green key"},
        {"BlueKey", "A blue key"},
        {"EscapeKey", "An old rusty key"}
    };
    // public bool redLockOpened = false;
    // public bool greenLockOpened = false;
    // public bool blueLockOpened = false;
    public bool secretDoorOpened = false; //TODO - set to private once finished testing
    private Dictionary<string, bool> allUnlockables = new Dictionary<string, bool>(){
        {"RedLock", false},
        {"GreenLock", false},
        {"BlueLock", false},
        {"ExitDoor", false}
    };

    // Make class a Singleton.
    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    // Initialise inventory slots
    void Start() {
        allItems = new String[10]{"empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty"};
        slot1.text = allItems[0];
        slot2.text = allItems[1];
        slot3.text = allItems[2];
        slot4.text = allItems[3];
    }

    // #####
    // ##### Set & Get Currently Selected Inventory
    // #####

    // invoked by Inventory GUI Button onclick methods
    public void setInventoryCurrentlySelected(TextMeshProUGUI item){ 
        Debug.Log("trying to set currentlySelected from item_name: " + item.text);

        // from the name of the item given
        // lookup the associated text from keyGUIText (getDictKeyFromValue())
        // ( item.text is the text displayed on GUI )
        string key_name = getDictKeyFromValue(item.text);
        inventoryCurrentlySelected = key_name;
    }

    // Resets value to "empty"
    public void resetCurrentlySelected() { 
        inventoryCurrentlySelected = ""; 
    }
    
    // returns name (string) of the item currently selected by user
    public string getInventoryCurrentlySelected(){ 
        return inventoryCurrentlySelected; 
        }

    // public access to if bookcase can now be opened by leverBook
    // N.B. 'canOpenBookcase' is set privately to protect clauses that need to be met
    public bool getIfCanOpenBookcase() { return canOpenBookcase; }
    
    // gives public access to boolean if player has all keys
    // N.B. 'hasAllKeys' is set privately to protect clauses that need to be met
    public bool getIfHasAllKeys() { return hasAllKeys; }

    public bool getIfSecretDoorOpened(){ return secretDoorOpened; }
    
    // local helper function used by addToInventory()
    // clear inventory slot then add image
    private void addToSlot(Button slot, TextMeshProUGUI slotText, Sprite new_image, GameObject item) { 
        // reset any text or images
        clearSlot(slot, slotText);

        // set transparency
        slot.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        
        // attach sprite image
        slot.image.sprite = new_image; 
        // set inner text
        slotText.text = KeyGUIText[item.name];
    }
    
    // local helper function used by addToInventory()
    // set image to null
    // set text to "empty"
    private void clearSlot(Button slot, TextMeshProUGUI slotText){

        // remove image from slot (Button)
        slot.image.sprite = null;

        // set transparancy of background:
        slot.GetComponent<Image>().color = new Color32(0, 0, 0, 45);  // Needs to be Color32 to use 0-255 value range. Using "new Color(" would require range 0-1.

        // get child TextMeshProUGUI element from the slot
        // set to default value "empty"
        slotText.text = "empty";
    }

    // core function for collecting items & clues
    // checks & sets for any conditions being met (eg., are all keys collected)
    // sets booleans when items & clues are collected
    // adds collected items to inventory GUI
    public void addToInventory (GameObject item) {
        Debug.Log("Prepping add to inventory" + item.name + item.GetInstanceID());
        
        // Don't allow add same object multiple times!
        // Check against items currently in inventory
        // shouldn't need this as objects will be set to inactive after selected...
        foreach (string obj in allItems) {
            if (obj != "empty") {
                if ( obj == item.name ) {
                    // Debug.Log("Err, This item is already in our inventory! " + item.name);
                    return;
                } else {
                    // Debug.Log( obj + " doesn't match: " + item.name + " and can be added");
                }
            }
        }
        
        // Add item to allItems
        int index = Array.IndexOf(allItems, "empty"); // find blank space in fixed array
        allItems[index] = item.name; // add item to found space

        bool displayOnGUI = false;
        Sprite imgToDisplay = null;
        // check for keys & clues
        switch(item.name){
            case "RedKey":
                hasRedKey = true;
                displayOnGUI = true;
                imgToDisplay = RedKeyImg;
                testIfAllKeysCollected();
                break;
            case "BlueKey":
                hasBlueKey = true;
                displayOnGUI = true;
                imgToDisplay = BlueKeyImg;
                testIfAllKeysCollected();
                break;
            case "GreenKey":
                hasGreenKey = true;
                displayOnGUI = true;
                imgToDisplay = GreenKeyImg;
                testIfAllKeysCollected();
                tryToOpenBookcase();
                break;
            case "EscapeKey":
                hasEscapeKey = true;
                displayOnGUI = true;
                imgToDisplay = EscapeKeyImg;
                break;
            case "AuthorClue":
                hasFoundAuthor = true;
                break;
            case "TitleClue":
                hasFoundTitle = true;
                break;
            case "MonsterClue":
                hasFoundMonster = true;
                tryToOpenBookcase();
                break;
            case "AgathaBook":
                hasFoundAuthorBook = true;
                tryToOpenBookcase();
                break;
            case "MobyBook":
                hasFoundTitleBook = true;
                tryToOpenBookcase();
                break;
        }
        
        if (displayOnGUI){
        // Find & add to inventory slot that is empty:
            if (slot1.text == "empty") { addToSlot(s1, slot1, imgToDisplay, item); return; }
            if (slot2.text == "empty") { addToSlot(s2, slot2, imgToDisplay, item); return; }
            if (slot3.text == "empty") { addToSlot(s3, slot3, imgToDisplay, item); return; }
            if (slot4.text == "empty") { addToSlot(s4, slot4, imgToDisplay, item); return; }
        }
    }


    // #####
    // ##### Test for conditions
    // #####

    public void testIfAllKeysCollected() {
        if (hasRedKey && hasBlueKey && hasGreenKey) {
            hasAllKeys = true;
            Debug.Log("All keys collected");
        }
    }

    // if both two other books and the green key are collected & the monster image is found
    // the bookcase is now openable by clicking on the Monster book
    public void tryToOpenBookcase(){
        if (hasFoundAuthorBook && hasFoundTitleBook && hasGreenKey && hasFoundMonster){
            canOpenBookcase = true;
            Debug.Log("Bookcase can now be opened...");
        }
    }

    public void tryToUnlockSecretDoor(){
        Debug.Log("PlayerInventory.tryToUnlockSecretDoor() trying...");

        if (allUnlockables["RedLock"] && allUnlockables["GreenLock"] && allUnlockables["BlueLock"] ){

            Debug.Log("Secret door being set to unlocked...");
            GameManager.manager.setSecretRoomUnlocked(true);
            secretDoorOpened = true;
        }
    }

    // open the chest
    // add check to Chest gameObject to ask if it's open or shut

    // helper function that finds the given argument in allItems and resets that value to "empty"
    private void removeInventoryItem(string name_to_remove) {
        // get this items position and set that position to "empty".
        if (allItems.Contains(name_to_remove)){
            int index = Array.IndexOf(allItems, name_to_remove); 
            allItems[index] = "empty";
            return;
        }
        Debug.Log("Err. Tried to remove " + name_to_remove + " from inventory but couldn't find it!");
    }

    public void OpenLock(string lock_name){
        // Debug.Log("Unlocking the lock... " + lock_name);

        // update dictionary of booleans for if lock has been unlocked
        // Debug.Log("setting lock status to open");
        allUnlockables[lock_name] = true;
        // Debug.Log("Status of " + lock_name + " = " + allUnlockables[lock_name]);

        // key associated with value in GUI
        string currentSelection = getInventoryCurrentlySelected();
        // Debug.Log("currentlySelected key = " + currentSelection);

        string SelectionText = KeyGUIText[currentSelection];
        // Debug.Log("currentlySelected value = " + SelectionText);

        // remove key from full inventory list
        removeInventoryItem(currentSelection);
        // unselect
        resetCurrentlySelected();

        // set booleans
        tryToUnlockSecretDoor();

        //remove item from GUI
        // find which slot has been selected
        // reset display to "empty"
        if (slot1.text == SelectionText) { clearSlot(s1, slot1); return; }
        else if (slot2.text == SelectionText) { clearSlot(s2, slot2); return; }
        else if (slot3.text == SelectionText) { clearSlot(s3, slot3); return; }
        else if (slot4.text == SelectionText) { clearSlot(s4, slot4); return; }
    }

    public bool GetLockStatus(String lockName) {
        return allUnlockables[lockName];
    }

    // local helper function
    private string getDictKeyFromValue(string value){
        string dictKey = "";

        // get key attached to text
        foreach ( KeyValuePair<string, string> pair in KeyGUIText ) {
            if ( pair.Value == value ) {
                dictKey = pair.Key;
                break;
            }
        }

        return dictKey;
    }

}