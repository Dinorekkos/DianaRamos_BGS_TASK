using System.Collections;
using System.Collections.Generic;
using Dino.TopDown2D;
using UnityEngine;

namespace DINO.TopDown2D.BSG
{
    public class InteractionObject : MonoBehaviour
    {
        #region Seialized Fields

        [SerializeField] private GameObject _interaction;

        #endregion

        #region private variables

        private bool _canInteract;
        private string _idInteraction;
        private bool _isInteracting;

        #endregion

        #region public properties

        public bool CanInteract => _canInteract;

        public bool IsInteracting
        {
            get => _isInteracting;
            set => _isInteracting = value;
        }

        #endregion

        #region unity methods

        private void Start()
        {
            Initialize();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnCanInteract();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnStopInteracting();
            }
        }

        #endregion

        #region protected virtual methods

        protected virtual void OnCanInteract()
        {
            _interaction.SetActive(true);
            _canInteract = true;
            InteractionsManager.Instance.CurrentInteractionObject = this;
        }

        protected virtual void OnStopInteracting()
        {
            _interaction.SetActive(false);
            _isInteracting = false;
            _canInteract = false; 
            if(InteractionsManager.Instance != null) InteractionsManager.Instance.CurrentInteractionObject = null;
        }
        
        protected virtual void Initialize()
        {
            _interaction.SetActive(false);
            InputManager.Instance.InteractAction.action.performed += ctx => Interact();
        }

        protected virtual void Interact()
        {
            // if (_isInteracting)return;
            if (!_canInteract) return;
            _isInteracting = true;
            _interaction.SetActive(false);

        }

        #endregion

    }
}