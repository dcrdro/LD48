using System.Collections;
using UnityEngine;
using DG.Tweening;

    public class ChangeSkinBodyInt : InteractorBase
    {
        public override void OnInteract()
        {
            StartCoroutine(FinishProcess());
        }

        public override string Name => "";
        
        IEnumerator FinishProcess()
        {
            var player = FindObjectOfType<Player>();
            player.enableControl = false;
            
            yield return new WaitForSeconds(1f);
            player.DoApplyBody();
            
            yield return new WaitForSeconds(2f);
            player.enableControl = true;
        }
    }
