using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawerScales : MonoBehaviour
{
    private GameObject topDrawerTwo;

    void Start() {
        topDrawerTwo = GameObject.FindGameObjectsWithTag("SecretDrawer")[0];
    }

    private void OnMouseDown() {
        // If the secret drawer is unlocked it won't move when you click on the scales again:
        if (!GameManager.manager.getSecretDrawerUnlocked()) {
            StartCoroutine(SlideSecretDrawer());
        }
    }

    private IEnumerator SlideSecretDrawer() {
        GameManager.manager.setSecretDrawerUnlocked(true);
        Vector3 drawerStartPosition = topDrawerTwo.transform.position;
        Vector3 drawerEndPosition = new Vector3(drawerStartPosition.x - 0.5f, drawerStartPosition.y, drawerStartPosition.z);

        float timeElapsed = 0;
        while(timeElapsed < 1) {
            topDrawerTwo.transform.position = Vector3.Lerp(drawerStartPosition, drawerEndPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}