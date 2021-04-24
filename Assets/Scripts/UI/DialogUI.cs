using UnityEngine;
using UnityEngine.UI;

    public class DialogUI : MonoBehaviour
    {
        public Image leftImage;
        public Image rightImage;
        public Text leftText;
        public Text rightText;
        public GameObject leftRoot;
        public GameObject rightRoot;

        public Image GetImage(bool isLeft) => isLeft ? leftImage : rightImage;
        public Text GetText(bool isLeft) => isLeft ? leftText : rightText;
        public void EnableRoot(bool isLeft, bool on)
        {
            GameObject obj = isLeft ? leftRoot : rightRoot;
            GameObject obj2 = isLeft ? rightRoot : leftRoot;
            obj.SetActive(on);
            obj2.SetActive(!on);
        }

        public void DisableRoots()
        {
            leftRoot.SetActive(false);
            rightRoot.SetActive(false);
        }
    }
