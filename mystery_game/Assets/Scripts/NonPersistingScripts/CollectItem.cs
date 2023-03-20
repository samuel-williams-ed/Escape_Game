using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public void OnMouseDown() {
        // Debug.Log("item selected" + gameObject.name);
        PlayerInventory.manager.addToInventory(this.gameObject);
        gameObject.SetActive(false);
    }

}
