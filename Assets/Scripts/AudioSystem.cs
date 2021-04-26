using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioSystem : Singleton<AudioSystem>
{
    public AudioSource musicSource;

    public void PlaySound(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}