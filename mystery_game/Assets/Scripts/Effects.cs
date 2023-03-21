using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{

    PostProcessVolume volume;
    Vignette vignette;

    // void Awake() {
    //     vignette = ScriptableObject.CreateInstance<Vignette>();
    //     vignette.enabled.Override(true);
    //     vignette.intensity.Override(1f);
    //     volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);
    // }

    // public void runEffects() {
    //     StartCoroutine(startEffects());
    // }

    private IEnumerator startEffects() {
        Debug.Log("StartEffects coroutine is running");
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);

        float timeElapsed = 0;
        while (timeElapsed < 5) {
            // vignette.intensity.value = Mathf.Sin(timeElapsed);
            vignette.intensity.value = 0.8f;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    private void Update() {
        if (ScenesManager.manager.runEffects) {
            StartCoroutine(startEffects());
        }
    }

}


    // PostProcessVolume m_Volume;
    // Vignette m_Vignette;
    
    // void Start() {
    //     // Create an instance of a vignette
    //     m_Vignette = ScriptableObject.CreateInstance<Vignette>();
    //     m_Vignette.enabled.Override(true);
    //     m_Vignette.intensity.Override(1f);
    //     // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
    //     m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    // }
    
    // void Update() {
    //     // Change vignette intensity using a sinus curve
    //         m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    // }
    
    // void OnDestroy() {
    //     RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    // }
