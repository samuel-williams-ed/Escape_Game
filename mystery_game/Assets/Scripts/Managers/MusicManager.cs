using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    private static MusicManager musicManager = null;

    void Awake() {

        if (musicManager != null) {
            Destroy(gameObject);
        }
        else {
            musicManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.loop = true;
    }
}



