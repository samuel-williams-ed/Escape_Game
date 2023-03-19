using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectUIElement : MonoBehaviour
{
    public void selectInventoryItem() {
        PlayerInventory.manager.setSelectedItem(gameObject);
        Debug.Log("Player has selected from invenotry UI " + gameObject.name);
    }

    public void debug(){
        Debug.Log("Button has been clicked.");
    }
}
