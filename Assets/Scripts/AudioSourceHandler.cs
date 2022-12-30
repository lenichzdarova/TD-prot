using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceHandler
{
    private AudioSource _audioSource;

    public AudioSourceHandler(AudioSource audioSource)
    {
        audioSource.playOnAwake = false;
        _audioSource = audioSource;        
    }

    public void PlayAudioClip()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
