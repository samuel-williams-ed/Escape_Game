using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
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
    private GameObject[] allItems = new GameObject[]{};
    private GameObject inventoryCurrentlySelected;

    // #####
    // ##### conditionals for recording current game state 
    // #####

    public bool deskDrawerUnlocked = false; // contains blue key
    public bool hasFoundAuthor = false; // Agatha Christie clue found (green key) on note on desk (MVP) or inside desk drawer (Ext) 
    public bool hasFoundTitle = false; // Finds clue for Moby Dick by listening to radio
    public bool hasFoundMonster = false; // can only click monster book (& open bookcase) once monster found


    public bool hasFoundAuthorBook = false; // reveals green key behind the book
    public bool hasFoundTitleBook = false; // feedback to player: "I could swear I heard a click - like a break being released..."
    public bool canOpenBookcase = false; //can only open bookcase after ^two books are found


    public bool hasRedKey = false;  // in chest of drawers
    public bool hasBlueKey = false; // in desk drawer - needs to be unlocked by scales
    public bool hasGreenKey = false; // behind Agatha Christie (Christkey?) book
    public bool hasAllKeys = false; // allows player to try to open secret door locks
    
    // #####
    // ##### Unity Instance Methods
    // #####

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
    void Start() {
        slot1.text = "empty";
        slot2.text = "empty";
        slot3.text = "empty";
        slot4.text = "empty";
        inventoryCurrentlySelected = new GameObject(){};
    }

    // #####
    // ##### setters, getters & adders
    // #####

    public void addToInventory (GameObject item) {
        Debug.Log("adding to inventory" + item.name + item.GetInstanceID());
        
        // guard clauses
        if (allItems.Count() >= 4) { return; } // Don't allow more items than there are inventory slots:
        if (allItems.Contains(item)) { return; } // Can't add exact same object multiple times!
        
        // Add item to list of game objects in inventory:
        allItems.Append(item); 

        // check for keys & clues
        switch(item.name){
            case "RedKey":
                hasRedKey = true;
                checkIfAllKeysCollected();
                break;
            case "BlueKey":
                hasBlueKey = true;
                checkIfAllKeysCollected();
                break;
            case "GreenKey":
                hasGreenKey = true;
                checkIfAllKeysCollected();
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
            case "AuthorBook":
                hasFoundAuthor = true;
                checkIfCanOpenBookcase();
                break;
            case "TitleBook":
                hasFoundTitleBook = true;
                checkIfCanOpenBookcase();
                break;
        }

        // Find & add to inventory slot that is empty:
        if (slot1.text == "empty") { addToSlot(slot1, item.name); return; }
        if (slot2.text == "empty") { addToSlot(slot2, item.name); return; }
        if (slot3.text == "empty") { addToSlot(slot3, item.name); return; }
        if (slot4.text == "empty") { addToSlot(slot4, item.name); return; }
    }

    public void addToSlot(TextMeshProUGUI slot, string newItemName) {
        slot.text = newItemName;
    }

    // set selected inventory item by directly passing in
    // or use overloaded method that searches through 'allItems' using name of the item we want to select
    public void setSelectedItem(GameObject selected_item){
        if (allItems.Contains(selected_item)){ // can't assign an item we don't have!
            inventoryCurrentlySelected = selected_item;
        } else {
            Debug.Log("Err: Item - " + selected_item.name + " - tried to be selected but is not in players inventory!");
        }
    }
    public void setSelectedItem(string item_name){
        foreach(GameObject item in allItems){
            if (item.name == item_name){ 
                inventoryCurrentlySelected = item;
                Debug.Log(item_name + " selected");
                break;
            }
        }
    }
    public void chooseThisItem(TextMeshProUGUI item_textMesh){
        Debug.Log("Selecting " + item_textMesh.text + " for inventory.");
        string item_text = item_textMesh.text;
        setSelectedItem(item_text);
    }
    public GameObject getSelectedItem() {
        if ( allItems.Count() == 0 ) { 
            Debug.Log("Err: Tried to get the Selected Item from inventory but inventory list is empty!");
            return null; 
            }
        return inventoryCurrentlySelected;
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

    // if two other books and the monster image is found
    // the bookcase is now openable by clicking on the Monster book
    public void checkIfCanOpenBookcase(){
        if (hasFoundAuthorBook && hasFoundTitleBook && hasFoundMonster){
            canOpenBookcase = true;
            Debug.Log("Has found both books! Bookcase can now be opened...");
        }
    }

}
