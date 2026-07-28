using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip GetItemSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGetItem()
    {
        audioSource.PlayOneShot(GetItemSound);
    }
}
