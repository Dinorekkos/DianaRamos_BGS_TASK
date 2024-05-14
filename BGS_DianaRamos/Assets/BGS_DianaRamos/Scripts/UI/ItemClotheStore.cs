using System;
using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using DINO.Utility;
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
    private Color _color = Color.white;
    private bool _isPurchased = false;
    #endregion
    
    #region public methods

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
        
        _isPurchased = false;
        _purchasedIcon.SetActive(false);
        
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

    public void UpdateButtonState()
    {
        if(_button == null) _button = GetComponent<Button>();
        
        ButtonOptimizedAnim buttonOptimizedAnim = gameObject.GetComponent<ButtonOptimizedAnim>();
        if (buttonOptimizedAnim != null)
        {
            buttonOptimizedAnim.ResetNormalColor(Color.white);
        }
        
        if (!_isPurchased)
        {
            _button.interactable = CurrencyManager.Instance.CanAfford(_itemPrice);
            // Debug.Log("Can afford: " + CurrencyManager.Instance.CanAfford(_itemPrice) + _itemID);
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

    
    public bool CanAfford()
    {
        return CurrencyManager.Instance.CanAfford(_itemPrice);
    }
    #endregion

    public void SetColor(Color color)
    {
        _color = color;
        _icon.color = color;
    }
}
