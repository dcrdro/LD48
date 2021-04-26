using System.Collections;
using UnityEngine;
using DG.Tweening;

    public class ChangeSkinHandsInt : InteractorBase
    {
        public AudioClip clip;
        public override void OnInteract()
        {
            Dialoguer.Instance.OnDialogEnd += End;
        }

        public override string Name => "";

        void End()
        {
            Dialoguer.Instance.OnDialogEnd -= End;
            StartCoroutine(FinishProcess());

        }
        
        IEnumerator FinishProcess()
        {
            var player = FindObjectOfType<Player>();
            player.enableControl = false;
            
            yield return new WaitForSeconds(1f);
            player.DoApplyLHand();
            player.DoApplyRHand();
            
            AudioSystem.Instance.PlaySound(clip);
            
            yield return new WaitForSeconds(2f);
            player.enableControl = true;
        }
    }
