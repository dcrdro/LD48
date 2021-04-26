using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScenesManager : Singleton<ScenesManager>
{
    public GameObject[] scenes;

    public int currentLevel = 0;
    public Player player;

    private int switchToLevel;
    private Transform playerParent;

    private void Awake()
    {
        foreach (var scene in scenes)
        {
            scene.SetActive(false);
        }
        
        scenes[currentLevel].SetActive(true);

        player = FindObjectOfType<Player>();
        playerParent = player.transform.parent.transform;
        playerParent.position = scenes[currentLevel].GetComponentInChildren<StartPoint>().transform.position;
        switchState();
    }

    public void goToLevel(int levelNumber)
    {
        switchToLevel = levelNumber;
        StartCoroutine(switchLevel());
    }

    IEnumerator switchLevel()
    {
        FadeManager.Instance.FadeTo(1f);
        yield return new WaitForSeconds(3);
        
        scenes[currentLevel].SetActive(false);
        scenes[switchToLevel].SetActive(true);
        playerParent.position = scenes[switchToLevel].GetComponentInChildren<StartPoint>().transform.position;
        currentLevel = switchToLevel;

        switchState();
        FadeManager.Instance.FadeTo(0f);
    }

    private void switchState()
    {
        switch (currentLevel)
        {
            case 0:
                MusicSystem.Instance.changeEnvironment(MusicSystem.environmentMusic.Peaceful);
                break;
            case 1:
                MusicSystem.Instance.changeEnvironment(MusicSystem.environmentMusic.Nostalgia);
                break;
            case 2:
                MusicSystem.Instance.changeEnvironment(MusicSystem.environmentMusic.Office);
                break;
            case 3:
                MusicSystem.Instance.changeEnvironment(MusicSystem.environmentMusic.Enigma);
                break;
        }
    }
}
