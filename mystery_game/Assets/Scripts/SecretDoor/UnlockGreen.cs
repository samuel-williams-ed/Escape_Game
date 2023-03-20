using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnlockGreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() {
        if ( PlayerInventory.manager.askIfHasAllKeys() ) {
            if ( PlayerInventory.manager.getInventoryCurrentlySelected() == "GreenKey" ){
                PlayerInventory.manager.OpenGreenLock();
                Debug.Log("Attempting to open green lock....");
            }
        }
    }
}

