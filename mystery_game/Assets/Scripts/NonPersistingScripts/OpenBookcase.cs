using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookcase : MonoBehaviour
{
    private Vector3 bookStartPosition;
    private Vector3 bookEndPosition;
    private bool bookSliding;
    private GameObject bookcase;
    private Vector3 bookcaseStartPosition;
    private Vector3 bookcaseEndPosition;
    private bool bookcaseSliding;
    private float timeElapsed;
    // private float lerpDuration = 3;

    // Start is called before the first frame update
    void Start() {
        bookStartPosition = transform.position;
        bookEndPosition = new Vector3(bookStartPosition.x, bookStartPosition.y, bookStartPosition.z + 0.1f);

        bookcase = transform.parent.gameObject;
        bookcaseStartPosition = bookcase.transform.position;
        bookcaseEndPosition = new Vector3(bookcaseStartPosition.x +1.5f, bookcaseStartPosition.y, bookcaseStartPosition.z);
    }

    private void OnMouseDown() {
        if (PlayerInventory.manager.getIfCanOpenBookcase()){
            bookSliding = true;
            GameManager.manager.UpdateDialogue(new List<string>(){"It's opened! I can hear it moving..."});
        }
        // else : maybe add some prompt for the user here 
        // "This book won't budge! It's fixed in position.. odd..."
        GameManager.manager.UpdateDialogue(new List<string>(){"The book won't budge! It's fixed in place... how strange..."});
        
    }

    // Update is called once per frame
    void Update() {
        if (bookSliding) {
            if (timeElapsed < 1) {
                float interpolationRatio = timeElapsed/1;
                transform.position = Vector3.Lerp(bookStartPosition, bookEndPosition, interpolationRatio);
                timeElapsed += Time.deltaTime;
            } else {
                bookSliding = false;
                timeElapsed = 0;
                bookcaseSliding = true;
            }
        }

        if (bookcaseSliding) {
            if (timeElapsed < 2) {
                float interpolationRatio = timeElapsed/2;
                bookcase.transform.position = Vector3.Lerp(bookcaseStartPosition, bookcaseEndPosition, interpolationRatio);
                timeElapsed += Time.deltaTime;
            } else {
                bookcaseSliding = false;
                GameManager.manager.setBookcaseUnlocked(true);
            }
        }

        if (GameManager.manager.getBookcaseUnlocked() && bookcase.transform.position != bookcaseEndPosition){
            Debug.Log("function running");
            bookcase.transform.position = bookcaseEndPosition;
        }
    }
}
