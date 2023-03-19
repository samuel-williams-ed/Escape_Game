using UnityEngine;
using TMPro;
using System;

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
    private string inventoryCurrentlySelected;

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
    public bool hasBlueKey = false; // in desk drawer - needs to be unlocked by scales
    public bool hasGreenKey = false; // behind Agatha Christie (Christkey?) book
    private bool hasAllKeys = false; // allows player to try to open secret door locks

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
        
        // Trialling this in the function after checkign if it has been found!
        // find objects that are collectable and will need to be hidden later
        // AuthorBook = GameObject.Find("AgathaBook").gameObject;
        // TitleBook = GameObject.Find("MobyBook").gameObject;
    }

    // Start is called before the first frame update
    // Initialise inventory slots
    void Start() {
        allItems = new String[5]{"empty", "empty", "empty", "empty", "empty"};
        slot1.text = allItems[0];
        slot2.text = allItems[1];
        slot3.text = allItems[2];
        slot4.text = allItems[3];
        slot5.text = allItems[4];
        inventoryCurrentlySelected = slot1.text;
    }

    // #####
    // ##### setters, getters
    // #####

    public void setInventoryCurrentlySelected(string item_name){ inventoryCurrentlySelected = item_name; }
    public string getInventoryCurrentlySelected(){ return inventoryCurrentlySelected; }

    // #####
    // ##### adders & askers
    // #####

    // gives public access to boolean if bookcase is openeable 
    // this is set privately to protect clauses that need to be met
    public bool askIfCanOpenBookcase(){ return canOpenBookcase; }
    
    // gives public access to boolean if player has all keys
    // this is set privately to protect clauses that need to be met
    public bool askIfHasAllKeys(){ return hasAllKeys; }
    
    // local helper function used by addToInventory()
    private void addToSlot(TextMeshProUGUI slot, string newItemName) { slot.text = newItemName; }

    // core function for collecting items & clues
    // checks & sets for any conditions being met (eg., all keys collected)
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
                    Debug.Log("Err, This item is already in our inventory! " + item.name);
                    return;
                } else {
                    Debug.Log( obj + " doesn't match: " + item.name + " and can be added");
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
                displayOnGUI = true;
                checkIfCanOpenBookcase();
                break;
            case "MobyBook":
                hasFoundTitleBook = true;
                displayOnGUI = true;
                checkIfCanOpenBookcase();
                break;
        }
        
        if (displayOnGUI){
        // Find & add to inventory slot that is empty:
            if (slot1.text == "empty") { addToSlot(slot1, item.name); return; }
            if (slot2.text == "empty") { addToSlot(slot2, item.name); return; }
            if (slot3.text == "empty") { addToSlot(slot3, item.name); return; }
            if (slot4.text == "empty") { addToSlot(slot4, item.name); return; }
            if (slot5.text == "empty") { addToSlot(slot5, item.name); return; }
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

}