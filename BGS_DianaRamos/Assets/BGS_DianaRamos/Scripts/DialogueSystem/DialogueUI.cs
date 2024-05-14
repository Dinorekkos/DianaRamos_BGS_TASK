using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using DINO.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace DINO.TopDown2D.BSG
{
    public class DialogueUI : MenuWindow
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _openStoreButton;

        protected override void Initialize()
        {
            base.Initialize();
            _closeButton.onClick.AddListener(() => CloseWindow());
            _openStoreButton.onClick.AddListener(() => OpenStore());
            

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