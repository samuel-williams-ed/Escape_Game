using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnlyObjectsScript : MonoBehaviour

{
    private GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        gameManager.UpdateDialogue("It doesn't look like I need to go in here");
    }

}
