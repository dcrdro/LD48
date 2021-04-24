using UnityEngine;
using UnityEngine.UI;

    public class ItemUI : MonoBehaviour
    {
        public Image icon;
        public Text name;

        public void SetIcon(Sprite i) => icon.sprite = i;
        public void SetName(string n) => name.text = n;

    }
