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

        private DialogData _activeDialogue;
        private int _index = 0;
        private Sequence _sequence;

        public void Show(DialogID id)
        {
            StartDialogue(DialogDatas[(int) id]);
        }

        private void Update()
        {
            if (!_activeDialogue) return;
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (_sequence != null && _sequence.IsPlaying())
                {
                    _sequence.Complete();
                }
                else
                {
                    ShowNextMonolog();
                }
            }
        }

        void StartDialogue(DialogData dialog)
        {
            // disable control
            UiManager.Instance.DialogUI.gameObject.SetActive(true);
            
            _activeDialogue = dialog;
            _index = 0;

            ScenesManager.Instance.player.DisableControl();
            
            ShowMonolog(dialog.monologs[_index]);
        }

        void FinishDialogue()
        {
            UiManager.Instance.DialogUI.DisableRoots();
            UiManager.Instance.DialogUI.gameObject.SetActive(false);
            // enable control
            
            _activeDialogue = null;

            ScenesManager.Instance.player.enableControl = true;
            
            OnDialogEnd?.Invoke();
        }

        void ShowNextMonolog()
        {
            if (++_index >= _activeDialogue.monologs.Length)
            {
                FinishDialogue();
                return;
            }
            
            ShowMonolog(_activeDialogue.monologs[_index]);
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

            _sequence = DOTween.Sequence();
            _sequence.Append(text.DOText(monologData.phrase, len).SetEase(Ease.Linear));

            _sequence.OnKill(() => _sequence = null);

        }

    }
