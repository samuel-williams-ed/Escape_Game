using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Effects : MonoBehaviour
{
    PostProcessVolume volume;
    Vignette vignette;
    Grain grain;
    ChromaticAberration chromaticAberration;


    void OnEnable() {
        // Create vignette:
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);

        // Create grain effect:
        grain = ScriptableObject.CreateInstance<Grain>();
        grain.enabled.Override(true);
        grain.intensity.Override(1f);

        // Create chromatic aberration effect:
        chromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromaticAberration.enabled.Override(true);
        chromaticAberration.intensity.Override(1f);

        // Create post process volume to contain required effects:
        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette, grain, chromaticAberration);
        StartCoroutine(startEffects());
    }

    private IEnumerator startEffects() {

        float timeElapsed = 0;
        while (timeElapsed < 1) {
            vignette.intensity.Override(1f - timeElapsed);
            grain.intensity.Override(1f - timeElapsed);
            chromaticAberration.intensity.Override(1f - timeElapsed);
            timeElapsed += (Time.deltaTime / 10f);
            yield return null;
        }

    }

}