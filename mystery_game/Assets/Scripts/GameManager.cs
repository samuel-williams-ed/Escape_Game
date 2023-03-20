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
    private float textSpeed = 0.15f;
    // private bool dialogueInProgress;


    private GameObject bookcase;
    private bool bookcaseUnlocked = false;
    private bool secretRoomUnlocked = false;
    private bool secretDrawerUnlocked = false;
    private bool padlockUnlocked = false;
    private bool exitDoorUnlocked = false;

    private List<string> getStartingText(){
        string string1 = "Where am I?";
        string string2 = "I'm in a room";
        string string3 = "it's badly decorated and it smells funny";
        List<string> startingText = new List<string>();
        startingText.Add(string1);
        startingText.Add(string2);
        startingText.Add(string3);

        return startingText;
    }
    
    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }

        scenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
        player = GameObject.Find("Player");
        bookcase = GameObject.Find("SecretBookcaseGroup").gameObject;
    }

    // Start is called before the first frame update
    void Start(){
        // index = 0;
        dialogueList = new List<string>();
        List<string> startingText = getStartingText();
        UpdateDialogue(startingText);

        PlayerMove.manager.setPlayerMoveable(true);
        PlayerLook.manager.setPlayerCanMoveCamera(true);

        scenesManager.removeBackButton();
    }
    
    public void UpdateDialogue(List<string> newListOfStrings){
        dialogueList = newListOfStrings;
        StartCoroutine(OutputDialogue());
    }

    IEnumerator OutputDialogue() {
        // Have a bool to track if dialogue already in progress?
        // dialogueInProgress = true;

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
            yield return new WaitForSeconds(textSpeed * 5);
            // Once all characters have been added, empty the dialogue text for next line:
            dialogueText.text = string.Empty;
        }

        // Reset lines variable to an empty array and add holding dialogue text:
        dialogueList = new List<string>();
        dialogueText.text = "...";

        // dialogueInProgress = false;
    }

    public bool getBookcaseUnlocked(){
        return bookcaseUnlocked;
    }
    public void setBookcaseUnlocked( bool true_or_false){
        bookcaseUnlocked = true_or_false;
    }
    public bool getSecretRoomUnlocked(){
        return secretRoomUnlocked;
    }
    public void setSecretRoomUnlocked(bool true_or_false) {
        secretRoomUnlocked = true_or_false;
    }
    public void setSecretDrawerUnlocked(bool true_or_false){
        secretDrawerUnlocked = true_or_false;
    }
    public bool getPadlockUnlocked() {
        return padlockUnlocked;
    }
    public void setPadlockUnlocked(bool trueFalse) {
        padlockUnlocked = trueFalse;
    }
    public bool getExitDoorUnlocked() {
        return exitDoorUnlocked;
    }
    public void setExitDoorUnlocked(bool trueFalse) {
        exitDoorUnlocked = trueFalse;
    }
}


