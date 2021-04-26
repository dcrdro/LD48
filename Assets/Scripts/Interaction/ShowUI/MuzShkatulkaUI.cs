using System;
using UnityEngine;

namespace Interaction
{
    public class MuzShkatulkaUI : MonoBehaviour
    {
        public string truePass;
        public string InterName;
        public string InterObjName;
        InteractorBase[] interactors;

        void Awake()
        {
            var root = GameObject.Find(InterName).transform.Find(InterObjName);
            interactors = root.GetComponentsInChildren<InteractorBase>();
        }

        public void PassEntered(string pass)
        {
            if (pass == truePass)
            {
                Complete();
            }    
        }

        void Complete()
        {
            Debug.Log("compl()");
            UiManager.Instance.HideItem();
            foreach (var interactorBase in interactors)
            {
                interactorBase.OnInteract();
            }
        }
    }
}