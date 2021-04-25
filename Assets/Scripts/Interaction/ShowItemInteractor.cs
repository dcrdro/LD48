using UnityEngine;

    public class ShowItemInteractor : InteractorBase
    {
        public GameObject showObject;
        
        public override void OnInteract()
        {
            UiManager.Instance.ShowItem(showObject);
        }

        public override string Name => "show item";
    }
