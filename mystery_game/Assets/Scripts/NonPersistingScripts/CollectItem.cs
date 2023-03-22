using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public void OnMouseDown() {
        PlayerInventory.manager.addToInventory(this.gameObject);
        gameObject.SetActive(false);
    }

}
