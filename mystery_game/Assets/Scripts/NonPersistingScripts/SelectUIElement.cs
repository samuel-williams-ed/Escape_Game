using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SelectUIElement : MonoBehaviour
{

    // inventory 'slot' TextMeshPro will run this when parent 'slot' button is selectd by player
    // gameObject = TextMeshPro object on slotx
    public void selectInventoryItem() {
        PlayerInventory.manager.chooseThisItem(gameObject.GetComponent<TextMeshProUGUI>());
        Debug.Log("UI registered click, running function setSelectedItem on " + gameObject.name);
    }

}
