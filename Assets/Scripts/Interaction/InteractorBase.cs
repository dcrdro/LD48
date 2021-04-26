using UnityEngine;

public abstract class InteractorBase : MonoBehaviour
{
    public abstract void OnInteract();
    public abstract string Name { get; }
    public virtual bool CanInteract => true;
}
