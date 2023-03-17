using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnRadio : MonoBehaviour
{
    private Transform radio;

    // Start is called before the first frame update
    void Start() {
        radio = transform.Find("Radio").gameObject.transform;
    }

    private void OnMouseDown() {
        Vector3 playerEndPosition = new Vector3(-3.75f, 0.9f, -3.5f);
        PlayerMove.manager.FocusPlayer(radio, playerEndPosition, "Radio");
    }

}

