using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCabinet : MonoBehaviour
{

    private bool cabinetOpen;
    // Start is called before the first frame update
    void Start()
    {
        cabinetOpen = false;
    }

    private void OnMouseDown()
    {
        if (cabinetOpen) {
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            cabinetOpen = false;
        } else {
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            cabinetOpen = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
