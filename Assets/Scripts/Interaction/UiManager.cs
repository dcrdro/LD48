using System.Collections;
using UnityEngine;

    public class UiManager : Singleton<UiManager>
    {
        public Transform showRoot;
        public GameObject interObj;
        public GameObject titry;
        
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
            Debug.Log("showingItem = " + showingItem);
            if (showingItem != null)
            {
                Destroy(showingItem);
                showRoot.gameObject.SetActive(false);
                Inventory.Instance.SelectItem(-1);

                if (showingItem.name.StartsWith("Mohyly"))
                {
                    StartCoroutine(FinishProcess());
                }
            }
        }

        public void ShowInterText() => interObj.SetActive(true);
        public void HideInterText() => interObj.SetActive(false);
        
        IEnumerator FinishProcess()
        {
            var player = FindObjectOfType<Player>();
            player.enableControl = true;
            
            yield return new WaitForSeconds(1f);
            player.DoApplyLLeg();
            player.DoApplyRLeg();

            yield return new WaitForSeconds(2f);
            FadeManager.Instance.FadeTo(1, 3f);
            yield return new WaitForSeconds(3f);
            titry.SetActive(true);
        }
    }
