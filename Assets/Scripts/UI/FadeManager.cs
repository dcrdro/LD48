using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : Singleton<FadeManager>
{
    private Image image;
    public float duration = 3f;
    public bool fadeOnStart = true;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        FadeTo(0f, fadeOnStart ? duration : 0f);
    }
    
    

    public void FadeTo(float to, float duration = 3f)
    {
        var fader = image.DOFade(to, duration).OnStart(() => image.enabled = true);

        if (to <= 0.1f) fader.OnComplete(() => image.enabled = false);
    }
}
