using UnityEngine;

    public class PickupItemInteractor : InteractorBase
    {
        public ItemData item;
        public string pickupName;
        
        public override void OnInteract()
        {
            Inventory.Instance.AddItem(item);
            Destroy(gameObject);
        }

        public override string Name => pickupName;
    }
