    using Dialogues;
    using UnityEngine.Timeline;

    public class DialogInteractor : InteractorBase
    {
        public DialogID dialogIndex;
        
        public override void OnInteract()
        {
            Dialoguer.Instance.Show(dialogIndex);
        }

        public override string Name => "поговорить";
    }
