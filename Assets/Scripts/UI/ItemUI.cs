using UnityEngine;
using UnityEngine.UI;

    public class ItemUI : MonoBehaviour
    {
        public Image icon;
        public Text name;
        public GameObject selection;
        public Text idx;

        public void SetIcon(Sprite i) => icon.sprite = i;
        public void SetName(string n) => name.text = n;
        public void Select(bool on) => selection.SetActive(on);
        public void SetIndex(int id) => idx.text = id.ToString();
    }
