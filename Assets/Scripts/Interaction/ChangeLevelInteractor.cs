using UnityEngine;
using DG.Tweening;

    public class ChangeLevelInteractor : InteractorBase
    {
        public int index;
        
        public override void OnInteract()
        {
            ScenesManager.Instance.goToLevel(index);
        }

        public override string Name => "";
    }
