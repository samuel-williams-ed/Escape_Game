using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPadlock : MonoBehaviour
{
    private Dictionary<string, int> currentCode = new Dictionary<string, int>() {
        {"Dial1", 1},
        {"Dial2", 8},
        {"Dial3", 4},
        {"Dial4", 0}
    };
    private string correctCode = "2951";
    private List<string> padlockUnlockedText = new List<string>() {
        "*CLICK*",
        "Got it! Now let's see what's in here..."
    };
    private GameObject chest;

    void Awake() {
        chest = GameObject.Find("SRChest").gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (getCurrentCode() == correctCode && !GameManager.manager.getPadlockUnlocked()) {
            GameManager.manager.setPadlockUnlocked(true);
            GameManager.manager.UpdateDialogue(padlockUnlockedText);
            // ADD FUNCTION / COROUTINE THAT CARRIED OUT THE FOLLOWING:
            // ANIMATION OF PADLOCK UNLOCKING
            // ANIMATION OF CHEST OPENING
            // LOAD SCENE THAT ZOOMS TO CHEST
            PlayerMove.manager.FocusPlayer(chest, new Vector3(3.5f, 1f, -7.9f));
            // SETS PADLOCK FOCUS SCRIPT TO FALSE / INACTIVE OR NOW LOADS CHEST SCENE?
        }
    }

    public string getCurrentCode() {
        string dial1Value = currentCode["Dial1"].ToString();
        string dial2Value = currentCode["Dial2"].ToString();
        string dial3Value = currentCode["Dial3"].ToString();
        string dial4Value = currentCode["Dial4"].ToString();
        return dial1Value + dial2Value + dial3Value + dial4Value;
    }

    public void updateDialValue(GameObject dial) {
        if (currentCode[dial.name] == 9) {
            currentCode[dial.name] = 0;
        } else {
            currentCode[dial.name] += 1;
        }
    }

}
