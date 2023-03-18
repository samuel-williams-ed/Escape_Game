using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOneOpen : MonoBehaviour
{
    private bool drawerOneOpen;
    private GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        drawerOneOpen = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("CLICK!!!");
        if (drawerOneOpen) {
            transform.position = new Vector3(transform.position.x +0.45f, transform.position.y, transform.position.z);

        } else {
            transform.position = new Vector3(transform.position.x -0.45f, transform.position.y, transform.position.z);
            drawerOneOpen = true;

            List<string> drawerOneText = new List<string>();
            drawerOneText.Add("This doesn't look helpful");
            gameManager.UpdateDialogue(drawerOneText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
