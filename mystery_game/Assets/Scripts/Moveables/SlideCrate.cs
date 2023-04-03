using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCrate : MonoBehaviour
{
    private Vector3 crateEndPosition;
    private bool crateMoved = false;

    private void OnMouseDown() {
        if (crateMoved) {
            crateEndPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.3f);
            crateMoved = false;
        } else {
            crateEndPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
            crateMoved = true;
        }
        StartCoroutine(MoveCrate());
    }

    private IEnumerator MoveCrate() {
        float timeElapsed = 0;
        while(timeElapsed < 1) {
            transform.position = Vector3.Lerp(transform.position, crateEndPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
