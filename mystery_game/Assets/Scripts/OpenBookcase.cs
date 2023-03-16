using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookcase : MonoBehaviour
{
    private GameObject bookcase;
    private Vector3 bookcaseStartPosition;
    private Vector3 bookcaseEndPosition;
    private bool bookcaseSliding;
    private float timeElapsed;
    private float lerpDuration = 3;

    // Start is called before the first frame update
    void Start() {
        bookcase = transform.parent.gameObject;
        bookcaseStartPosition = bookcase.transform.position;
        bookcaseEndPosition = new Vector3(bookcaseStartPosition.x +1.5f, bookcaseStartPosition.y, bookcaseStartPosition.z);
    }

    private void OnMouseDown() {
        Debug.Log("CLICK");
        bookcaseSliding = true;
    }

    // Update is called once per frame
    void Update() {
        if (bookcaseSliding) {
            if (timeElapsed < lerpDuration) {
                float interpolationRatio = timeElapsed/lerpDuration;
                bookcase.transform.position = Vector3.Lerp(bookcaseStartPosition, bookcaseEndPosition, interpolationRatio);
                timeElapsed += Time.deltaTime;
            } else {
                bookcaseSliding = false;
            }
        }
    }
}
