using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerFiveOpen : MonoBehaviour
{
    private bool drawerFiveOpen;
    private GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        drawerFiveOpen = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("CLICK!!!");
        if (drawerFiveOpen) {
            transform.position = new Vector3(transform.position.x +0.45f, transform.position.y, transform.position.z);

        } else {
            transform.position = new Vector3(transform.position.x -0.45f, transform.position.y, transform.position.z);
            drawerFiveOpen = true;

            List<string> drawerFiveText = new List<string>();
            drawerFiveText.Add("What a load of junk!");
            gameManager.UpdateDialogue(drawerFiveText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}