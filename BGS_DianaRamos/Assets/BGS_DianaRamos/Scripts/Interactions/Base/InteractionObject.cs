using System.Collections;
using System.Collections.Generic;
using Dino.TopDown2D;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    #region Seialized Fields
    
    [SerializeField] private GameObject _interaction;
    #endregion

    #region private variables
    private bool _canInteract;
    private string _idInteraction;
    #endregion

    #region public properties
    public bool CanInteract => _canInteract;
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
            _interaction.SetActive(true);
            _canInteract = true;
            InteractionsManager.Instance.CurrentInteractionObject = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _interaction.SetActive(false);
            _canInteract = false;
            InteractionsManager.Instance.CurrentInteractionObject = null;
        }
    }
    #endregion

    #region protected virtual methods
    
    protected virtual void Initialize()
    {
        _interaction.SetActive(false);
        InputManager.Instance.InteractAction.action.performed += ctx => Interact();
    }
    protected virtual void Interact()
    {
        if (!_canInteract) return;
        _interaction.SetActive(false);
        
    }
    
    #endregion

    
}
