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
    public GameObject player;
    public bool runEffects = false;
    // public Button startGameButton;
    private List<string> introText = new List<string>() {
        "Where am I?",
        "I need to get out of here..."
    };
    public Dictionary<string, string> scenes = new Dictionary<string, string>() {
        {"ExitDoorFocus", "ExitDoor"},
        {"SecretBookcaseGroup", "SecretDoor"},
        {"Radio", "Radio"},
        {"PictureColourFocus", "PictureColour"},
        {"Desk", "Desk"},
        {"ChestOfDrawersFocus", "ChestOfDrawers"},
        {"Padlock", "Padlock"},
        {"SRChest", "Chest"},
        {"CrateFocus", "Crate"}
    };
    // private GameObject bookcase;

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
        player.SetActive(true);

        // Set player start position:
        player.transform.position = new Vector3(-3f, 0.5f, -0.5f);
        player.transform.eulerAngles = new Vector3(0f, 90f, -45f);
        Camera.main.transform.position = new Vector3(0f, 0.8f, 0f);

        yield return new WaitForSeconds(1.5f);
        // Make this longer, currently cuts out some of the intro stuff?
        // while (SceneManager.GetActiveScene().buildIndex != 1) {
        //     yield return null;
        // }

        // Add blur / vignette effect to screen and gradually remove??
        // runEffects = true;
        // float timeElapsed = 0;
        // while (timeElapsed < 5) {
        //     yield return null;
        // }
        // runEffects = false;

        gameUICanvas.SetActive(true);
        removeBackButton();
        GameManager.manager.UpdateDialogue(introText);

        // Add in player movement: CURRENTLY NOT SMOOTH, NEED TO FIX!!!
        float timeElapsed = 0;
        while (timeElapsed < 2) {
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(-2.5f, 1f, -0.5f), timeElapsed / 2);
            player.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            timeElapsed += Time.deltaTime;
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
        SceneManager.LoadScene("Credits"); // TODO - Indira please confirm credits scene name
        player.SetActive(false);

        yield return null;
    }

     // Two returns deal with the player coming to the cabinet from different sides (finds the objects x position and the players x position and calculate the angle of rotation to do this)
    // public Quaternion FindPlayerEndRotation(Vector3 objectPosition, Vector3 playerPosition) {
    //     if (objectPosition.x >= playerPosition.x) {
    //         return Quaternion.FromToRotation(new Vector3(objectPosition.x, 0, 0), new Vector3(playerPosition.x, 0, 0));
    //     } else {
    //         return Quaternion.FromToRotation(new Vector3(objectPosition.x, 0, 0), new Vector3(-playerPosition.x, 0, 0));
    //     }
    // }

    // public Quaternion OpenLeftDoorEndRotation() {
    //     return Quaternion.FromToRotation(Vector3.forward, Vector3.right);
    // }

    // public Quaternion OpenRightDoorEndRotation() {
    //     return Quaternion.FromToRotation(Vector3.forward, Vector3.left);
    // }

    // add/remove button when changing scenes
    public void addBackButton(){
        backButton.gameObject.SetActive(true);
    }
    public void removeBackButton(){
        backButton.gameObject.SetActive(false);
    }
}
