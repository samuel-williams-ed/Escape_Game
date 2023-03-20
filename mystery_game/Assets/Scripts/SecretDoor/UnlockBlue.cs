using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() {
        if ( PlayerInventory.manager.askIfHasAllKeys() ) {
            if ( PlayerInventory.manager.getInventoryCurrentlySelected() == "BlueKey" ){
                PlayerInventory.manager.OpenBlueLock();
                Debug.Log("Blue lock unlocked!");
            }
        }
    }
}

