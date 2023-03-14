using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private bool drawerOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawerOpen = false;
    }

    private void OnMouseDown()
    {
        if (drawerOpen) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);
            drawerOpen = false;
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.4f);
            drawerOpen = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
