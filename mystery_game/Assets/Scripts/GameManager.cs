using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour

{

    public TextMeshProUGUI dialogueText;
    private List<string> lines = new List<string>();
    private int index; // to track where we are within the dialogue
    private float textSpeed = 0.02f;
    // public void UpdateDialogue(string newDialogue){
    //     dialogueText.text = newDialogue;
    // }

    private List<string> getStartingText(){
        string string1 = "Where am I?";
        string string2 = "I'm in a room";
        string string3 = "it's badly decorated and it smells funny";
        List<string> startingText = new List<string>();
        startingText.Add(string1);
        startingText.Add(string2);
        startingText.Add(string3);

        return startingText;
    }
    

    // Start is called before the first frame update
    void Start(){
        // UpdateDialogue("...");
        List<string> startingText = getStartingText();
        UpdateDialogue(startingText);
    }
    
    public void UpdateDialogue(List<string> newListOfStrings){
        lines.AddRange(newListOfStrings);
        index = 0;
        StartCoroutine(TypeLine());
    }
    //creating a co-routine
    IEnumerator TypeLine(){
        //Type each character one by one
        foreach (char character in lines[index].ToCharArray()){ // takes the string and breaks it down to a character array
        
            dialogueText.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Count -1){
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            // lines.Clear();
            lines = new List<string>();
            index = 0;
            dialogueText.text = "...";
            // gameObject.SetActive(false); // gameObject refers to panel. 

        }
    }

        // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){ // 0 is the left button

            if(dialogueText.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();

                dialogueText.text = lines[index];   // this will get the current line and instantly fill it out
            }
        }
    }
}

