using System;
using System.Collections;
using DG.Tweening;
using Dialogues;
using UnityEngine;

    public class Dialoguer : Singleton<Dialoguer>
    {
        public Sprite[] Sprites;
        public DialogData[] DialogDatas;
        
        public event Action OnDialogEnd;
        public float spl = 0.5f;
        
        public void Show(DialogID id)
        {
            StartCoroutine(ShowProcess(DialogDatas[(int) id]));
        }

        IEnumerator ShowProcess(DialogData dialog)
        {
            // disable control
            UiManager.Instance.DialogUI.gameObject.SetActive(true);

            foreach (var monolog in dialog.monologs)
            {
                ShowMonolog(monolog);
                float len = monolog.phrase.Length * spl;
                yield return new WaitForSeconds(len + 1);
            }
            UiManager.Instance.DialogUI.DisableRoots();
            UiManager.Instance.DialogUI.gameObject.SetActive(false);
            // enable control
            
            OnDialogEnd?.Invoke();
        }

        void ShowMonolog(DialogData.MonologData monologData)
        {
            var dialogUI = UiManager.Instance.DialogUI;
            dialogUI.EnableRoot(monologData.isLeft, true);
            Sprite icon = Sprites[(int) monologData.PersID];
            dialogUI.GetImage(monologData.isLeft).sprite = icon;
            var text = dialogUI.GetText(monologData.isLeft);
            text.text = "";
            float len = monologData.phrase.Length * spl;
            text.DOText(monologData.phrase, len).SetEase(Ease.Linear);

        }

    }
