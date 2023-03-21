using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePadlockDial : MonoBehaviour
{
    private OpenPadlock openPadlock;

    void Awake() {
        openPadlock = transform.parent.GetComponent<OpenPadlock>();
    }

    void OnMouseDown() {
        transform.Rotate(-36, 0, 0, Space.Self);
        openPadlock.updateDialValue(gameObject);
    }

}