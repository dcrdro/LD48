using UnityEngine;
using DG.Tweening;

    public class EnableBehaviorInteractor : InteractorBase
    {
        public Behaviour Behaviour;
        public bool isEnabled;
        
        public override void OnInteract()
        {
            Behaviour.enabled = isEnabled;
        }

        public override string Name => "";
    }
