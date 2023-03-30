using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainMusicLoad : MonoBehaviour

{
    private void Start() {
        if (GameObject.Find("MainMusic") is GameObject mainMusic) {
            mainMusic.GetComponent<AudioSource>().Stop();
        }
    }
}


