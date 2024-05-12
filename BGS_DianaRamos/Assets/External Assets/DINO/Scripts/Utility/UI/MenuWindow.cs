using System;
using DG.Tweening;
using UnityEngine;

namespace DINO.Utility
{ 
    public class MenuWindow : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Menu Window Settings")]
        [SerializeField] private Transform windowTransform;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float delay = 0f;
        [SerializeField] private Ease showEase = Ease.OutBack;
        [SerializeField] private Ease hideEase = Ease.InBack;

        #endregion

        #region public variables

        public Action OnStartShowingWindow;
        public Action OnFinishedShowingWindow;
        public Action OnStartHideWindow;
        public Action OnFinishedHideWindow;

        #endregion

        #region unity methods

        private void Start()
        {
            Initialize();
        }

        #endregion

        #region protected methods

        protected virtual void Initialize()
        {
            canvas.enabled = false;

        }

        #endregion

        #region public virtual methods

        public virtual void ShowWindow()
        {
            OnStartShowingWindow?.Invoke();
            canvas.enabled = true;
            windowTransform.DOScale(Vector3.one, duration).SetEase(showEase).SetDelay(delay).OnComplete(() =>
            {
                OnFinishedShowingWindow?.Invoke();
            });
        }

        public virtual void HideWindow()
        {
            OnStartHideWindow?.Invoke();
            windowTransform.DOScale(Vector3.zero, duration).SetEase(hideEase).SetDelay(delay).OnComplete(() =>
            {
                canvas.enabled = false;
                OnFinishedHideWindow?.Invoke();
            });
        }

        #endregion

    }
}