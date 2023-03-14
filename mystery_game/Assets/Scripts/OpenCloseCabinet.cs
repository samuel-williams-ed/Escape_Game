using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseCabinet : MonoBehaviour
{

    private bool cabinetOpen;
    // Start is called before the first frame update
    void Start()
    {
        cabinetOpen = false;
    }

    private void OnMouseDown()
    {
        if (!cabinetOpen) {
            // Set camera position in front of camera (and in 2D?) - should this be a new scene?
            // Rotate left door by 90 degrees
            // Rotate right door by 270 degrees
            cabinetOpen = true;
        } // else need to go back to main camera in room, rotate doors back to being closed and update cabinetOpen
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
