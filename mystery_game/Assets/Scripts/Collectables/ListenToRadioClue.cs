using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenToRadioClue : MonoBehaviour
{

    void OnMouseDown() {
        PlayerInventory.manager.hasFoundTitle = true;
        Debug.Log("Title Found.");
    }

}
