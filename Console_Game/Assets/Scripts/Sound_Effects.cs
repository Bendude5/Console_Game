using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effects : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] soundEffects;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playSoundEffect(int soundNumber)
    {
        audioSource.PlayOneShot(soundEffects[soundNumber]);
    }
}
