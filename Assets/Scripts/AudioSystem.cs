using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioSystem : MonoBehaviour
{
    public AudioSource musicSource;

    public void PlaySound(AudioClip clip)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
}