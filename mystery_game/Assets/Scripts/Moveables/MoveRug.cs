using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRug : MonoBehaviour {

    public GameObject rug;

    // if rug has already been moved when we load into this scene
    // set position to moved coordinates
    void Start() {
        if(GameManager.manager.getrugMoved()){
            gameObject.transform.Rotate(0, -25, 0);
            gameObject.transform.position = new Vector3(-1.5f, 0.15f, 3f);
        }
    }

    void OnMouseDown() {
        moveRug(rug);
    }

    public void moveRug(GameObject rug_to_move){

        // if player position.z is > 2.2
        if (GameManager.manager.getPlayer().transform.position.z > 2.2 ){

            gameObject.transform.Rotate(0, -25, 0);
            gameObject.transform.position = new Vector3(-1.5f, 0.15f, 3f);

            Debug.Log("Moving rug " + gameObject.name);
            GameManager.manager.UpdateDialogue(new List<string>(){"What's this image hidden under the rug... must be important..."});

            GameManager.manager.setRugMoved(true);
        }
        
    }
}
