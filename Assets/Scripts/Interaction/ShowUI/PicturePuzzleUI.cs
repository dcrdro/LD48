using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Interaction
{
    public class PicturePuzzleUI : MonoBehaviour
    {
        public Transform root;
        public Transform[] puzzles;

        int objChosen1Index = -1;
        
        void Start()
        {
            for (int i = 0; i < root.childCount * 2; i++)
            {
                int i1 = Random.Range(0, root.childCount);
                int i2 = Random.Range(0, root.childCount);
                root.GetChild(i1).SetSiblingIndex(i2);
            }
        }
        
        public void Select(Transform obj)
        {
            if (objChosen1Index == -1)
            {
                objChosen1Index = obj.GetSiblingIndex();
            }
            else
            {
                int objChosen2Index = obj.transform.GetSiblingIndex();
                Transform objChosen1 = root.GetChild(objChosen1Index);
                obj.SetSiblingIndex(objChosen1Index);
                objChosen1.SetSiblingIndex(objChosen2Index);

                objChosen1Index = -1;
            }

            if (IsCompleted())
            {
                Debug.Log("Complte)(");
                UiManager.Instance.HideItem();
                UiManager.Instance.StartCoroutine(FinishProcess());
            }
        }

        bool IsCompleted()
        {
            for (int i = 0; i < puzzles.Length; i++)
            {
                if (puzzles[i] != root.GetChild(i)) return false;
            }

            return true;
        }

        IEnumerator FinishProcess()
        {
            var player = FindObjectOfType<Player>();
            player.enableControl = true;
            
            yield return new WaitForSeconds(1f);
            player.DoApplyHead();

            yield return new WaitForSeconds(2f);
            ScenesManager.Instance.goToLevel(1);
        }
    }
}