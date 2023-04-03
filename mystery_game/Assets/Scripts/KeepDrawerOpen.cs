using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KeepDrawerOpen : MonoBehaviour
{
    void Start() {
        if (GameManager.manager.getSecretDrawerUnlocked() == true){            
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
