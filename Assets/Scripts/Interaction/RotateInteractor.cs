using UnityEngine;
using DG.Tweening;

public class RotateInteractor : InteractorBase
{
    public Transform target;
    public Vector3 rotation;
    public float time;
    
    public override void OnInteract()
    {
        target.DORotate(rotation, time).SetRelative();
    }

    public override string Name => "";
}
