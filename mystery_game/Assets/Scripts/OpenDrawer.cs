using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private Vector3 drawerStartPosition;
    private Vector3 drawerEndPosition;
    private bool drawerOpen;
    private bool drawerSliding;
    private float timeElapsed;
    private float adjustment;

    // Start is called before the first frame update
    void Start() {
        // drawerStartPosition = transform.position;
        // drawerEndPosition = new Vector3(drawerStartPosition.x + 0.5f, drawerStartPosition.y, drawerStartPosition.z);
    }

    private void OnMouseDown() {
        drawerStartPosition = transform.position;
        if (gameObject.tag == "Desk") {
            adjustment = -0.5f;
        } else if (gameObject.tag == "Chest"){
            adjustment = 0.5f;
        }
        if (drawerOpen) {
            drawerEndPosition = new Vector3(drawerStartPosition.x + adjustment, drawerStartPosition.y, drawerStartPosition.z);
            drawerOpen = false;
        } else {
            drawerEndPosition = new Vector3(drawerStartPosition.x - adjustment, drawerStartPosition.y, drawerStartPosition.z);
            drawerOpen = true;
        }
        drawerSliding = true;        
    }


    // Update is called once per frame
    void Update() {
    if (drawerSliding) {
        if (timeElapsed < 1) {
            transform.position = Vector3.Lerp(drawerStartPosition, drawerEndPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
        } else {
            drawerSliding = false;
            transform.position = drawerEndPosition;
            }
        }
    }
}

