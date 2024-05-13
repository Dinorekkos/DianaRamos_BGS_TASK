using System;
using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemClotheStore : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private TextMeshProUGUI _itemCost;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    #endregion
    
    #region private variables
    private ClotheType _clotheType;
    private string _itemID; 
    private int _itemPrice;
    #endregion
    
    #region public methods

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);

    }

    public void Initialize(string itemID, Sprite itemSprite, int itemPrice, ClotheType clotheType)
    {
        _itemID = itemID;
        _icon.sprite = itemSprite;
        _itemPrice = itemPrice;
        _itemCost.text = itemPrice.ToString();
        _clotheType = clotheType;
        
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        if(_button == null) _button = GetComponent<Button>();
        _button.interactable = CurrencyManager.Instance.CanAfford(_itemPrice);
    }

    private void OnButtonClicked()
    {
        CurrencyManager.Instance.SpendCurrency(_itemPrice);
    }

    #endregion
    
}