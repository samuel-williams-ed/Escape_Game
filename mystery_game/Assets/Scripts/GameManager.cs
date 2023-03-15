using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour

{
    public TextMeshProUGUI dialogueText;
    public void UpdateDialogue(string newDialogue)
    {
        dialogueText.text = newDialogue;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateDialogue("..."); // This should really be an empty string - it's not showing anyways
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
