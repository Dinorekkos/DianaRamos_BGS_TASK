using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using DINO.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DINO.TopDown2D.BSG
{
    public class DialogueUI : MenuWindow
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _openStoreButton;
        [SerializeField] private TextMeshProUGUI _dialogueText;

        protected override void Initialize()
        {
            base.Initialize();
            _closeButton.onClick.AddListener(() => CloseWindow());
            _openStoreButton.onClick.AddListener(() => OpenStore());

            DialogueManager.Instance.OnDialogueStart += SetDialogue;


        }

        private void SetDialogue(Dialogue dialogue)
        {
            StartCoroutine(SetDialogueTxt(dialogue));
        }
        private IEnumerator SetDialogueTxt(Dialogue dialogue)
        {
            _dialogueText.text = "";
            foreach (char character in dialogue.Text.ToCharArray())
            {
                _dialogueText.text += character;
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void OpenStore()
        {
            HideWindow();
            StartCoroutine(DelayedOpenStore());
        }

        private void CloseWindow()
        {
            HideWindow();
            PlayerMovement.Instance.EnableMovement(true);
        }

        private IEnumerator DelayedOpenStore()
        {
            yield return new WaitForSeconds(0.5f);
            MenuManager.Intance.OpenWindow(MenuManager.Intance.GetWindow("clothe.store"));

           
        }
        
       
    }
}