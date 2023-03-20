using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRug : MonoBehaviour {

    public GameObject rug;

    void OnMouseDown() {
        moveRug(rug);
    }

    public void moveRug(GameObject rug_to_move){
        Debug.Log("Moving rug " + gameObject.name);
        gameObject.transform.Rotate(0, -25, 0);
        // gameObject.transform.position = new Vector3(-170.711f, 77.4188f, 391.46f);

        GameManager.manager.UpdateDialogue(new List<string>(){"What's this image hidden under the rug... must be important..."});
    }
}
