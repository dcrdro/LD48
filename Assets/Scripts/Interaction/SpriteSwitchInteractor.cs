using UnityEngine;
using DG.Tweening;

    public class SpriteSwitchInteractor : InteractorBase
    {
        public SpriteRenderer rend;
        public Sprite sprite;
        
        public override void OnInteract()
        {
            rend.sprite = sprite;
        }

        public override string Name => "";
    }
