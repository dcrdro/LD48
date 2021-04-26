using UnityEngine;

    public class UseItemInteractor : InteractorBase
    {
        public InteractorBase[] usedInteractors;
        public ItemData item;

        bool suc = false;
        public override void OnInteract()
        {
            if (Inventory.Instance.selectedItem == item)
            {
                suc = true;
                Inventory.Instance.RemoveItem(item);
                Inventory.Instance.SelectItem(-1);
                foreach (var usedInteractor in usedInteractors)
                {
                    usedInteractor.OnInteract();
                }
            }
            else
            {
                suc = false;
            }
        }

        public override string Name => "use item";
        public override bool CanInteract => suc;
    }
