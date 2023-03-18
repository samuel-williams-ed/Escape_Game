using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class PlayerInventory : MonoBehaviour
{

    public static PlayerInventory manager;
    public TextMeshProUGUI slot1;
    public TextMeshProUGUI slot2;
    public TextMeshProUGUI slot3;
    public TextMeshProUGUI slot4;
    
    // chest of drawers (red)
    public bool hasRedKey = false;
    // location unknown (blue)
    public bool hasBlueKey = false;
    // behind Agatha Christie (Christkey?) book (green)
    public bool hasGreenKey = false;
    // check for monster/lever book to move bookcase
    public bool hasAllKeys = false;
    // Agatha Christie clue found (green key) on note on desk (MVP) or inside desk drawer (Ext) 
    public bool hasFoundAuthor = false;
    // Finds clue for Moby Dick by listening to radio
    public bool hasFoundTitle = false;

    public bool hasFoundMonster = false;
    private GameObject[] allItems = new GameObject[]{};

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
        // Might need to do conditional logic for scene changes to load in inventory
    }

    public void addToInventory (GameObject item) {
        Debug.Log("adding to inventory" + item.name + item.GetInstanceID());

        // Don't allow more items than there are inventory slots:
        if (allItems.Count() > 4) {
            return;
        }

        // Add item to list of game objects in inventory:
        allItems.Append(item);

        // refactored to switch block below
        // if (item.name == "RedKey") {
        //     hasRedKey = true;
        //     checkIfAllKeysCollected();
        // }

        // if (item.name == "BlueKey") {
        //     hasBlueKey = true;
        //     checkIfAllKeysCollected();
        // }

        // if (item.name == "GreenKey") {
        //     hasGreenKey = true;
        //     checkIfAllKeysCollected();
        // }

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
                break;
        }

        // Find the inventory slot that is empty:
        if (slot1.text == "empty") {
            addToSlot(slot1, item.name);
            return;
        }
        if (slot2.text == "empty") {
            addToSlot(slot2, item.name);
            return;
        }
        if (slot3.text == "empty") {
            addToSlot(slot3, item.name);
            return;
        }
        if (slot4.text == "empty") {
            addToSlot(slot4, item.name);
            return;
        }
    }

        public void addToSlot(TextMeshProUGUI slot, string newItemName) {
        slot.text = newItemName;
    }

    public void checkIfAllKeysCollected() {
        if (hasRedKey && hasBlueKey && hasGreenKey) {
            hasAllKeys = true;
            Debug.Log("All keys collected");
        }
    }

}
