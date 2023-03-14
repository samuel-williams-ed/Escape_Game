using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index; // to track where we are within the dialogue
    // Start is called before the first frame update
    void Start()
    {
        // lines = new string[]{};

        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 0 is the left button
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();

                textComponent.text = lines[index];   // this will get the current line and instantly fill it out
            }
        }
    }

    void StartDialogue()
    {
    
        index = 0;
        StartCoroutine(TypeLine());
    }
    //creating a co-routine
    IEnumerator TypeLine()
    {
        //Type each character one by one
        foreach (char character in lines[index].ToCharArray()) // takes the string and breaks it down to a character array
        {
            textComponent.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

        }
    }

}
