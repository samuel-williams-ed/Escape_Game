using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour

{
    public static GameManager manager;
    private ScenesManager scenesManager;
    private GameObject player;
    public TextMeshProUGUI dialogueText;
    private List<string> dialogueList;
    private List<string> introText = new List<string>() {
        "Where am I?",
        "I need to get out of here..."
    };
    private float textSpeed = 0.05f;
    private bool dialogueInProgress = false;
    private bool bookcaseUnlocked = false;
    private bool secretRoomUnlocked = false;
    private bool secretDrawerUnlocked = false;
    private bool padlockUnlocked = false;
    private bool chestOpened = false;
    private bool exitDoorUnlocked = false;
    private bool rugMoved = false;

    
    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }

        player = GameObject.Find("Player");
    }


    public void UpdateDialogue(List<string> newListOfStrings){
        dialogueList = newListOfStrings;
        if (!dialogueInProgress){
            StartCoroutine(OutputDialogue());
        }
    }

    IEnumerator OutputDialogue() {
        // Have a bool to track if dialogue already in progress?
        dialogueInProgress = true;

        // Empty holding text from dialogue box:
        dialogueText.text = string.Empty;

        // Loop through each string in the lines array:
        foreach (string line in dialogueList) {
            // Loop through each character in the string and print to dialogue box at given textSpeed:
            foreach (char character in line.ToCharArray()) {
                dialogueText.text += character;
                yield return new WaitForSeconds(textSpeed);
                if (Input.GetMouseButton(1)) { // If right-mouse button clicked, breaks loop and prints whole line
                    break;
                }
            }
            dialogueText.text = line;
            yield return new WaitForSeconds(1f);
            // Once all characters have been added, empty the dialogue text for next line:
            dialogueText.text = string.Empty;
        }

        // Reset lines variable to an empty array and add holding dialogue text:
        dialogueList = new List<string>();
        dialogueText.text = "...";

        dialogueInProgress = false;
    }

    public GameObject getPlayer(){
        if (player != null) {
            return player;
        } else {
            return GameObject.Find("Player");
        }
    }

    public bool getBookcaseUnlocked(){
        return bookcaseUnlocked;
    }
    public void setBookcaseUnlocked( bool trueFalse){
        bookcaseUnlocked = trueFalse;
    }
    public bool getSecretRoomUnlocked(){
        return secretRoomUnlocked;
    }
    public void setSecretRoomUnlocked(bool trueFalse) {
        secretRoomUnlocked = trueFalse;
    }
    public bool getSecretDrawerUnlocked() {
        return secretDrawerUnlocked;
    }
    public void setSecretDrawerUnlocked(bool trueFalse){
        secretDrawerUnlocked = trueFalse;
    }
    public bool getPadlockUnlocked() {
        return padlockUnlocked;
    }
    public void setPadlockUnlocked(bool trueFalse) {
        padlockUnlocked = trueFalse;
    }
    public bool getChestOpened() {
        return chestOpened;
    }
    public void setChestOpened(bool trueFalse) {
        chestOpened = trueFalse;
    }
    public bool getExitDoorUnlocked() {
        return exitDoorUnlocked;
    }
    public void setExitDoorUnlocked(bool trueFalse) {
        exitDoorUnlocked = trueFalse;
    }
    public bool getrugMoved(){
        return rugMoved;
    }
    public void setRugMoved(bool true_or_false){
        rugMoved = true_or_false;
    }
}


