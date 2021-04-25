using UnityEngine;

    public class UseItemInteractor : InteractorBase
    {
        public InteractorBase[] usedInteractors;
        public ItemData item;
        
        public override void OnInteract()
        {
            if (Inventory.Instance.selectedItem == item)
            {
                Inventory.Instance.RemoveItem(item);
                Inventory.Instance.SelectItem(-1);
                foreach (var usedInteractor in usedInteractors)
                {
                    usedInteractor.OnInteract();
                }
            }
        }

        public override string Name => "use item";
    }
