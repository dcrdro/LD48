using UnityEngine;

public class AudioInteractor : InteractorBase
{
    public AudioClip sound;
    
    public override void OnInteract()
    {
        AudioSystem.Instance.PlaySound(sound);
    }

    public override string Name => "";
}
