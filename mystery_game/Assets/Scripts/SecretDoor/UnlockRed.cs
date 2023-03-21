// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class UnlockRed : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     void OnMouseDown() {
//         if ( PlayerInventory.manager.askIfHasAllKeys() ) {
//             if ( PlayerInventory.manager.getInventoryCurrentlySelected() == "RedKey" ){
//                 PlayerInventory.manager.OpenRedLock();

//                 //Debug.Log("Red lock unlocked!");
//                 GameManager.manager.UpdateDialogue(new List<string>(){"The red key worked!"});
//             }
//         }
//     }
// }
