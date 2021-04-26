using System.Collections;
using UnityEngine;

namespace Interaction
{
    public class OnDEnd : InteractorBase
    {
        public InteractorBase intt;
        
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
            yield return new WaitForSeconds(12f);
            intt.OnInteract();
        }
    }
}