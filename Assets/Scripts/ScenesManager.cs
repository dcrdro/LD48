using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScenesManager : Singleton<ScenesManager>
{
    public GameObject[] scenes;

    public int currentLevel = 0;

    private int switchToLevel;
    private Transform player;

    private void Awake()
    {
        foreach (var scene in scenes)
        {
            scene.SetActive(false);
        }
        
        scenes[currentLevel].SetActive(true);

        player = FindObjectOfType<Player>().transform.parent.transform;
        player.position = scenes[currentLevel].GetComponentInChildren<StartPoint>().transform.position;
    }

    private void Start()
    {
        // StartCoroutine(goToLevel(1));
        goToLevel(1);
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
        player.position = scenes[switchToLevel].GetComponentInChildren<StartPoint>().transform.position;

        FadeManager.Instance.FadeTo(0f);
    }
}
