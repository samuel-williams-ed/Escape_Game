using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    AudioSource audioSource;


    private void Reset()
    {
        audioSource.playOnAwake = false;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
