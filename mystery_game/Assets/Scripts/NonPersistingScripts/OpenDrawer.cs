using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private Vector3 drawerEndPosition;
    private bool drawerOpen = false;
    private float adjustment;

    private void OnMouseDown() {
        if (gameObject.tag == "Desk") {
            adjustment = -0.5f;
        } else if (gameObject.tag == "Chest"){
            adjustment = 0.5f;
        }
        if (drawerOpen) {
            drawerEndPosition = new Vector3(transform.position.x + adjustment, transform.position.y, transform.position.z);
            drawerOpen = false;
        } else {
            drawerEndPosition = new Vector3(transform.position.x - adjustment, transform.position.y, transform.position.z);
            drawerOpen = true;
        }
        StartCoroutine(SlideDrawer());
    }

    private IEnumerator SlideDrawer() {
        float timeElapsed = 0;
        while(timeElapsed < 1) {
            transform.position = Vector3.Lerp(transform.position, drawerEndPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
