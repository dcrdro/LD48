using UnityEngine;

    public class UiManager : Singleton<UiManager>
    {
        public Transform showRoot;
        
        public DialogUI DialogUI;
        public InventoryUI InventoryUI;
        // public GiveItemUI GiveItemUI;
        // public MessageUI MessageUI;

        GameObject showingItem;
        
        public void ShowItem(GameObject obj)
        {
            if (showingItem == null)
            {
                showRoot.gameObject.SetActive(true);
                showingItem = Instantiate(obj, showRoot);
            }
        }

        public void HideItem()
        {
            if (showingItem != null)
            {
                Destroy(showingItem);
                showRoot.gameObject.SetActive(false);
                Inventory.Instance.SelectItem(-1);
            }
        }
    }
