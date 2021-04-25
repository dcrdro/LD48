using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;
    public float duration = 5f;
    public bool fadeOnStart = true;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        FadeTo(0f, fadeOnStart ? duration : 0f);
    }

    public void FadeTo(float to, float duration = 5f)
    {
        image.DOFade(0f, duration);
    }
}
