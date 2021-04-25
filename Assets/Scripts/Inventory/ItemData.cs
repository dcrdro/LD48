using UnityEngine;

    [CreateAssetMenu()]
    public class ItemData : ScriptableObject
    {
        public new string name;
        public Sprite icon;
        public GameObject showUIObject;
        public bool IsShowable => showUIObject != null;
    }
