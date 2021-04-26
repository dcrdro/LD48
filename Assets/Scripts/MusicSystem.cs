using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class MusicSystem : Singleton<MusicSystem>
{
    public enum environmentMusic
    {
        Peaceful,
        Nostalgia,
        Office,
        Enigma,
        Transformation
    }
    
    [Serializable]
    public struct BGMusic {
        public environmentMusic environment;
        public AudioClip audio;
    }

    public BGMusic[] musics;
    public AudioSource[] musicSources = new AudioSource[2];
    public bool playOnStart = true;
    
    private void Start()
    {
        if (playOnStart) changeEnvironment(environmentMusic.Peaceful);
    }

    public void changeEnvironment(environmentMusic environment, float duration = 5f)
    {
        AudioClip changeToMusic = null;
        foreach (var music in musics)
        {
            if (music.environment == environment)
            {
                changeToMusic = music.audio;
            }
        }
        
        if (changeToMusic) CrossFade(changeToMusic, duration);
    }

    void CrossFade(AudioClip to, float duration)
    {
        AudioSource activeSource = musicSources[0].isPlaying ? musicSources[0] : musicSources[1];
        AudioSource extraSource = musicSources[0].isPlaying ? musicSources[1] : musicSources[0];
        
        DOTween.To(() => activeSource.volume, vol => activeSource.volume = vol, 0f, duration).OnComplete(() => activeSource.Stop());
        extraSource.clip = to;
        extraSource.volume = 0f;
        extraSource.Play();
        DOTween.To(() => extraSource.volume, vol => extraSource.volume = vol, 1f, duration);
    }
}