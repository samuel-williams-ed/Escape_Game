using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRug : MonoBehaviour {

    public GameObject rug; // needs to be assigned in the Heirarchy
    public GameObject seaMonster; // needs to be assigned in the Heirarchy
    // seaMonster MUST BE NAMED 'MonsterClue'
    // gameObject.name is checked in PlayerInventory.addToInventory()

    // if rug has already been moved before we load into this scene, set position to moved coordinates:
    void Start() {
        if ( GameManager.manager.getrugMoved() ){
            gameObject.transform.Rotate(0, -25, 0);
            gameObject.transform.position = new Vector3(-1.5f, 0.15f, 3f);
        }
    }

    void OnMouseDown() {
        moveRug(rug);
    }

    public void moveRug(GameObject rug_to_move){

        // only allow if player position.z is > 2 (closer than edge of rug):
        if (GameManager.manager.getPlayer().transform.position.z > 2 ){

            // Don't allow rug to move more than once - exit function if already moved!
            if ( GameManager.manager.getrugMoved() ) { return; }

            // position rug (positions relative to parent 'RugClue' gameObject)
            Quaternion rugEndRotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(-1f, 0f, 1f));
            float timeElapsed = 0;
            while (timeElapsed < 1) {
                transform.rotation = Quaternion.Slerp(transform.rotation, rugEndRotation, timeElapsed);
                timeElapsed += (Time.deltaTime);
            }

            GameManager.manager.UpdateDialogue(new List<string>(){"What's this image hidden under the rug..."});
            GameManager.manager.setRugMoved(true); // set so rug moving will persist

            // set Sea Monster as having been found in case user doesn't click on plank!
            PlayerInventory.manager.addToInventory(seaMonster); 
        }
        
    }
}