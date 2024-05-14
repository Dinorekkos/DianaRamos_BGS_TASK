using System;
using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemClotheStore : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private TextMeshProUGUI _itemCostTxt;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _purchasedIcon;
    [SerializeField] private GameObject _cost;

    #endregion
    
    #region private variables
    private ClotheType _clotheType;
    private string _itemID; 
    private int _itemPrice;
    private int _itemIndex;
    private Color _color;
    private bool _isPurchased;
    #endregion
    
    #region public methods

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
        
        _isPurchased = false;
        _purchasedIcon.SetActive(false);
        
        
        if(_clotheType == ClotheType.Hair) _color = _icon.color;
    }

    public void Initialize(string itemID, Sprite itemSprite, int itemPrice, ClotheType clotheType, int itemIndex)
    {
        _itemID = itemID;
        _icon.sprite = itemSprite;
        _itemPrice = itemPrice;
        _itemCostTxt.text = itemPrice.ToString();
        _clotheType = clotheType;
        _itemIndex = itemIndex;
        
        
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        if(_button == null) _button = GetComponent<Button>();

        if (!_isPurchased)
        {
            _button.interactable = CurrencyManager.Instance.CanAfford(_itemPrice);
            _purchasedIcon.SetActive(false);
        }
        else
        {
            _button.interactable = true;
            _purchasedIcon.SetActive(true);
            _cost.SetActive(false);
        }
    }
    

    private void OnButtonClicked()
    {
        if (!_isPurchased)
        {
            CurrencyManager.Instance.SpendCurrency(_itemPrice);
            _isPurchased = true;
            UpdateButtonState();
        }

        if (_clotheType == ClotheType.Hair)
        {
            CharacterPartSelector.Instance.OnHairColorChange?.Invoke(_color);
        }
        
        CharacterPartSelector.Instance.ChangeBodyPart(_clotheType.ToString(), _itemIndex); 

    }

    #endregion

    public void SetColor(Color color)
    {
        _color = color;
        _icon.color = color;
    }
}
