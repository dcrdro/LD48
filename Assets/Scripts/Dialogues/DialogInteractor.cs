    public class DialogInteractor : InteractorBase
    {
        public DialogData[] dialogs;

        public int dialogIndex;

        public int giverRequiredInex;
        public InteractorBase giver;
        
        public override void OnInteract()
        {
            Dialoguer.Instance.Show(dialogs[dialogIndex]);
            if (giver && dialogIndex == giverRequiredInex) giver.OnInteract();
        }

        public override string Name => "поговорить";
    }
