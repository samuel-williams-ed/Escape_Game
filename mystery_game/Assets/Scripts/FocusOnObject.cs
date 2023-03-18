using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnObject : MonoBehaviour
{
    private Dictionary<string, Vector3> playerEndPositions = new Dictionary<string, Vector3>() {
        {"Radio", new Vector3(-3.75f, 0.9f, -3.5f)},
        {"PictureColour", new Vector3(-4f, 1.2f, 2.7f)}
    };


    private void OnMouseDown() {
        Vector3 playerEndPosition = playerEndPositions[gameObject.name];
        PlayerMove.manager.FocusPlayer(gameObject, playerEndPosition);
    }

}

