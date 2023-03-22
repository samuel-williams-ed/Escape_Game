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
    private string correctCode = "8412";
    private List<string> padlockUnlockedText = new List<string>() {
        "* CLICK * ... I'm in!",
    };
    private GameObject chest;
    private GameObject chestLid;
    private GameObject player;

    void Awake() {
        chest = GameObject.Find("SRChest").gameObject;
        chestLid = chest.transform.Find("ChestTop").gameObject;
        player = GameObject.Find("Player").gameObject;
    }

    void Start() {
        if ( GameManager.manager.getPadlockUnlocked() ) {
            Debug.Log("Chest lid is open");
            chestLid.transform.eulerAngles = new Vector3(chestLid.transform.eulerAngles.x, chestLid.transform.eulerAngles.y, -90f);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        if (getCurrentCode() == correctCode && !GameManager.manager.getPadlockUnlocked()) {
            GameManager.manager.setPadlockUnlocked(true);
            GameManager.manager.UpdateDialogue(padlockUnlockedText);
            StartCoroutine(OpenChest());
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

    private IEnumerator OpenChest() {
        // Set end rotation for Chest Lid:
        chestLid.transform.Rotate(new Vector3(0f, 0f, -90f));

        // Following moves player over time period of 1 second:
        float timeElapsed = 0;
        while (timeElapsed < 1) {
            player.transform.position = Vector3.Lerp(transform.position, new Vector3(2.8f, 1.4f, -7.5f), timeElapsed);
            player.transform.LookAt(chest.transform);
            Camera.main.transform.LookAt(chest.transform);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        ScenesManager.manager.LoadScene("Chest");
        gameObject.SetActive(false);
    }

}