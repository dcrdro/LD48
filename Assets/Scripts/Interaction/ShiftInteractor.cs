using UnityEngine;
using DG.Tweening;

    public class ShiftInteractor : InteractorBase
    {
        public Transform target;
        public Vector3 shift;
        public float time;
        
        public override void OnInteract()
        {
            print("move");
            target.DOMove(shift, time).SetRelative();
        }

        public override string Name => "";
    }
