using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawerScales : MonoBehaviour
{
    private Vector3 drawerStartPosition;
    private Vector3 drawerEndPosition;
    // private bool drawerOpen;
    private float timeElapsed;
    //private GameObject chestOfDrawers;
    private GameObject topDrawerTwo;
    private bool drawerSliding;

    // Start is called before the first frame update
    void Start() {
        topDrawerTwo = GameObject.FindGameObjectsWithTag("SecretDrawer")[0];
    }

    private void OnMouseDown() {
        drawerStartPosition = topDrawerTwo.transform.position;
        drawerEndPosition = new Vector3(drawerStartPosition.x + 0.5f, drawerStartPosition.y, drawerStartPosition.z);
        drawerEndPosition = new Vector3(drawerStartPosition.x - 0.5f, drawerStartPosition.y, drawerStartPosition.z);
        GameManager.manager.setSecretDrawerUnlocked(true);
        drawerSliding = true;  
    }

    // Update is called once per frame
    void Update() {
    if (drawerSliding) {
        if (timeElapsed < 1) {
            topDrawerTwo.transform.position = Vector3.Lerp(drawerStartPosition, drawerEndPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
        } else {
            drawerSliding = false;
            topDrawerTwo.transform.position = drawerEndPosition;
            }
        }
    }
}
