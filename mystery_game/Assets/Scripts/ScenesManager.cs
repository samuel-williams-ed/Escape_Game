using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager manager;
    public GameObject gameUICanvas;
    public Button backButton;
    private GameObject player;
    private GameObject playerCamera;
    private GameObject playerEffects;
    
    private List<string> introText = new List<string>() {
        "Where am I?",
        "I need to get out of here..."
    };
    public Dictionary<string, string> scenes = new Dictionary<string, string>() {
        // {"key = object to focus on", "value = scene name"}
        {"ExitDoorFocus", "ExitDoor"},
        {"SecretBookcaseGroup", "SecretDoor"},
        {"Radio", "Radio"},
        {"PictureColourFocus", "PictureColour"},
        {"WeeDesk", "Desk"},
        {"ChestOfDrawersFocus", "ChestOfDrawers"},
        {"Padlock", "Padlock"},
        {"SRChest", "Chest"},
        {"CrateFocus", "Crate"}
    };

    //  make me a singlton
    void Awake() {
        if (manager == null) {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } else {
            if (manager != this) {
                Destroy(gameObject);
            }
        }
        player = GameObject.Find("Player").gameObject;
        playerCamera = player.transform.Find("Camera").gameObject;
        playerEffects = player.transform.Find("Effects").gameObject;
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
        addBackButton();
    }

    public void LoadMainRoom(){
        SceneManager.LoadScene("EscapeRoom");
        removeBackButton();
    }


    public void StartGame() {
        StartCoroutine(SetupGame());
    }

IEnumerator SetupGame() {
        SceneManager.LoadScene("EscapeRoom");

        // Make this longer, currently cuts out some of the intro stuff?
        while (SceneManager.GetActiveScene().buildIndex != 1) {
            yield return null;
        }

        playerCamera.SetActive(true);
        playerEffects.SetActive(true);

        // Set player start position:
        player.transform.position = new Vector3(-3f, 0.5f, -0.5f);
        player.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        playerCamera.transform.localPosition = new Vector3(0f, 0.8f, 0f);

        // Activate UI elements via canvas and run start dialogue:
        gameUICanvas.SetActive(true);
        removeBackButton();
        GameManager.manager.UpdateDialogue(introText);

        // Add in player movement:
        float timeElapsed = 0;
        while (timeElapsed < 1) {
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(-2.5f, 1f, -0.5f), timeElapsed);
            timeElapsed += (Time.deltaTime / 4f);
            yield return null;
        }

        PlayerMove.manager.setPlayerMoveable(true);
        PlayerLook.manager.setPlayerCanMoveCamera(true);
        yield return null;
    }

    public void EndGame(){
        StartCoroutine(GoToCredits());
    }

    IEnumerator GoToCredits() {

        // disable player actions & GUI
        PlayerMove.manager.setPlayerMoveable(false);
        PlayerLook.manager.setPlayerCanMoveCamera(false);
        gameUICanvas.SetActive(false);
        
        // load credits scene and disable player
        SceneManager.LoadScene("EndOfAdventure");
        player.SetActive(false);

        yield return null;
    }

    // add/remove button when changing scenes
    public void addBackButton(){
        backButton.gameObject.SetActive(true);
    }
    public void removeBackButton(){
        backButton.gameObject.SetActive(false);
    }
}
