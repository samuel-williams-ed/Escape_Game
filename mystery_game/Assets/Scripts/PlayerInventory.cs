using UnityEngine;
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
    public TextMeshProUGUI slot1;
    public TextMeshProUGUI slot2;
    public TextMeshProUGUI slot3;
    public TextMeshProUGUI slot4; 
    public TextMeshProUGUI slot5;

    private string[] allItems; // should be name (string) of each item as GameObjects won't persist across scenes!
    
    // dictionary 'key' (from KeyGUIName) associated with inventory GUI item selected
    public string inventoryCurrentlySelected;

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
    
    public Dictionary<string, string> KeyGUIName = new Dictionary<string, string>(){
        {"RedKey", "A red key"},
        {"GreenKey", "A green key"},
        {"BlueKey", "A blue key"},
        {"EscapeKey", "An old rusty key"}
    };
    // public bool redLockOpened = false;
    // public bool greenLockOpened = false;
    // public bool blueLockOpened = false;
    public bool secretDoorOpened = false; //TODO - set to private once finished testing
    public Dictionary<string, bool> allUnlockables = new Dictionary<string, bool>(){
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
        // slot1.text = "RedKey"; // for testing
        // slot2.text = "BlueKey"; // for testing
        slot3.text = allItems[2];
        slot4.text = allItems[3];
        slot5.text = allItems[4];
        // inventoryCurrentlySelected = slot1.text;
    }

    // #####
    // ##### setters, getters
    // #####

    // Only for use in resetting the value to empty;
    private void setInventoryCurrentlySelected(string item_name){ 
        inventoryCurrentlySelected = item_name; 
        }
    public void setInvenotryCurrentlySelected(TextMeshProUGUI item){ 
        Debug.Log("trying to set currently selected from item_name: " + item.text);

        // assign equal to key
        inventoryCurrentlySelected = getDictKeyFromValue(item.text);
        }

    private string getDictKeyFromValue(string value){
        string dictKey = "";

        // get key attached to text
        foreach ( KeyValuePair<string, string> pair in KeyGUIName ) {
            if ( pair.Value == value ) {
                dictKey = pair.Key;
                break;
            }
        }

        return dictKey;
    }

    public string getInventoryCurrentlySelected(){ 
        return inventoryCurrentlySelected; 
        }

    // #####
    // ##### adders & askers
    // #####

    // gives public access to boolean if bookcase is openeable 
    // this is set privately to protect clauses that need to be met
    public bool askIfCanOpenBookcase() { return canOpenBookcase; }
    
    // gives public access to boolean if player has all keys
    // this is set privately to protect clauses that need to be met
    public bool askIfHasAllKeys() { return hasAllKeys; }

    public bool askIfSecretDoorOpened(){
        return secretDoorOpened;
    }
    
    // local helper function used by addToInventory()
    private void addToSlot(TextMeshProUGUI slot, string newItemName) { slot.text = newItemName; }

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
        // check for keys & clues
        switch(item.name){
            case "RedKey":
                hasRedKey = true;
                displayOnGUI = true;
                checkIfAllKeysCollected();
                break;
            case "BlueKey":
                hasBlueKey = true;
                displayOnGUI = true;
                checkIfAllKeysCollected();
                break;
            case "GreenKey":
                hasGreenKey = true;
                displayOnGUI = true;
                checkIfAllKeysCollected();
                checkIfCanOpenBookcase();
                break;
            case "EscapeKey":
                hasEscapeKey = true;
                displayOnGUI = true;
                break;
            case "AuthorClue":
                hasFoundAuthor = true;
                break;
            case "TitleClue":
                hasFoundTitle = true;
                break;
            case "MonsterClue":
                hasFoundMonster = true;
                checkIfCanOpenBookcase();
                break;
            case "AgathaBook":
                hasFoundAuthorBook = true;
                checkIfCanOpenBookcase();
                break;
            case "MobyBook":
                hasFoundTitleBook = true;
                checkIfCanOpenBookcase();
                break;
        }
        
        if (displayOnGUI){
        // Find & add to inventory slot that is empty:
            if (slot1.text == "empty") { addToSlot(slot1, KeyGUIName[item.name]); return; }
            if (slot2.text == "empty") { addToSlot(slot2, KeyGUIName[item.name]); return; }
            if (slot3.text == "empty") { addToSlot(slot3, KeyGUIName[item.name]); return; }
            if (slot4.text == "empty") { addToSlot(slot4, KeyGUIName[item.name]); return; }
            if (slot5.text == "empty") { addToSlot(slot5, KeyGUIName[item.name]); return; }
        }
    }


    // #####
    // ##### conditional checks
    // #####

    public void checkIfAllKeysCollected() {
        if (hasRedKey && hasBlueKey && hasGreenKey) {
            hasAllKeys = true;
            Debug.Log("All keys collected");
        }
    }

    // if both two other books and the green key are collected & the monster image is found
    // the bookcase is now openable by clicking on the Monster book
    public void checkIfCanOpenBookcase(){
        if (hasFoundAuthorBook && hasFoundTitleBook && hasGreenKey && hasFoundMonster){
            canOpenBookcase = true;
            Debug.Log("Bookcase can now be opened...");
        }
    }

    public void checkIfSecretDoorUnlocked(){
        Debug.Log("PlayerInventory.CheckIfSecretDoor() run...");

        if (allUnlockables["RedLock"] && allUnlockables["GreenLock"] && allUnlockables["BlueLock"] ){

            Debug.Log("Secret door being set to unlocked...");
            GameManager.manager.setSecretRoomUnlocked(true);
            secretDoorOpened = true;
            // get secretDoor object & call open door script
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

    // Called by 'lock' gameObjects, when clicked each calls to their respective color
    // locks handle check for correct key selected
    // public void OpenRedLock(){
    //     redLockOpened = true;
    //     setInventoryCurrentlySelected("empty"); 
    //     removeInventoryItem("RedKey");
    //     checkIfSecretDoorUnlocked();
    // }
    // public void OpenGreenLock(){
    //     greenLockOpened = true;
    //     setInventoryCurrentlySelected("empty");
    //     removeInventoryItem("GreenKey");
    //     Debug.Log("Green lock opened!");
    //     checkIfSecretDoorUnlocked();
    // }
    // public void OpenBlueLock(){
    //     blueLockOpened = true;
    //     setInventoryCurrentlySelected("empty");
    //     removeInventoryItem("BlueKey");
    //     checkIfSecretDoorUnlocked();
    // }

    public void OpenLock(string lock_name){
        Debug.Log("Unlocking the lock... " + lock_name);

        // update dictionary of booleans for if lock has been unlocked
        Debug.Log("setting lock status to open");
        allUnlockables[lock_name] = true;
        Debug.Log("Status of " + lock_name + " = " + allUnlockables[lock_name]);

        // key associated with value in GUI
        string currentSelection = getInventoryCurrentlySelected();
        Debug.Log("currentlySelected key = " + currentSelection);

        string SelectionText = KeyGUIName[currentSelection];
        Debug.Log("currentlySelected value = " + SelectionText);

        // remove key from full inventory list
        removeInventoryItem(currentSelection);
        // unselect
        setInventoryCurrentlySelected("empty");

        // set booleans
        checkIfSecretDoorUnlocked();

        //remove item from GUI
        // find which slot has been selected
        // reset display to "empty"
            if (slot1.text == SelectionText) { slot1.text = "empty"; return; }
            else if (slot2.text == SelectionText) { slot2.text = "empty"; return; }
            else if (slot3.text == SelectionText) { slot3.text = "empty"; return; }
            else if (slot4.text == SelectionText) { slot4.text = "empty"; return; }
            else if (slot5.text == SelectionText) { slot5.text = "empty"; return; }
    }



}