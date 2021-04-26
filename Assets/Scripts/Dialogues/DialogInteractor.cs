    using Dialogues;
    using UnityEngine.Timeline;

    public class DialogInteractor : InteractorBase
    {
        public DialogID dialogIndex;
        public bool giveItem;
        public ItemData item;
        
        public override void OnInteract()
        {
            Dialoguer.Instance.Show(dialogIndex);
            if (giveItem) Inventory.Instance.AddItem(item);
        }

        public override string Name => "поговорить";
    }
