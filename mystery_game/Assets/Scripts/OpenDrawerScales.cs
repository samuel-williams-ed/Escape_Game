using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawerScales : MonoBehaviour
{
    private Vector3 drawerStartPosition;
    private Vector3 drawerEndPosition;
    private bool drawerOpen;
    private float timeElapsed;
    //private GameObject chestOfDrawers;
    private GameObject topDrawerTwo;

    // Start is called before the first frame update
    void Start()
    {
        // aFinger = transform.Find("LeftShoulder/Arm/Hand/Finger");
        // topDrawerTwo = transform.Find("TopDrawer2");
        //chestOfDrawers = GameObject.Find("ChestOfDrawers");
        //topDrawerTwo = GameObject.Find("TopDrawer2");
        // GameObject go = GameObject.FindGameObjectsWithTag("Player");
        topDrawerTwo = GameObject.FindGameObjectsWithTag("SecretDrawer");
    }

    private void OnMouseDown() {
        Debug.Log("CLICK");
        drawerStartPosition = topDrawerTwo.transform.position;
        if (drawerOpen) {
            drawerEndPosition = new Vector3(drawerStartPosition.x + 0.5f, drawerStartPosition.y, drawerStartPosition.z);
            drawerOpen = false;
        } else {
            drawerEndPosition = new Vector3(drawerStartPosition.x - 0.5f, drawerStartPosition.y, drawerStartPosition.z);
            drawerOpen = true;
        }   
    }
}
