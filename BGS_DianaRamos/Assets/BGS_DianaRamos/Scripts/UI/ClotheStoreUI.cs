using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DINO.TopDown2D.BSG;
using DINO.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClotheStoreUI : MenuWindow
{
    #region Serialized Fields
    [SerializeField] private ItemStoreData _itemStoreData;

    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _hairTab;
    [SerializeField] private Button _torsoTab;

    [SerializeField] private GameObject _hairTabContent;
    [SerializeField] private GameObject _torsoTabContent;

    [SerializeField] private List<ItemClotheStore> _hairItems = new List<ItemClotheStore>();
    [SerializeField] private List<ItemClotheStore> _torsoItems = new List<ItemClotheStore>();

    #endregion
    private ClotheType _currentClotheType = ClotheType.Torso;

    
    protected override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(() => CloseWindow());

        _hairTab.onClick.AddListener(() => ChangeTab(ClotheType.Hair));
        _torsoTab.onClick.AddListener(() => ChangeTab(ClotheType.Torso));
        InitializeItems();
        UpdateTabContent();
        
        
    }

    private void CloseWindow()
    {
        HideWindow();
        PlayerMovement.Instance.EnableMovement(true);

    }

    private void ChangeTab(ClotheType clotheType)
    {
        _currentClotheType = clotheType;
        UpdateTabContent();

    }

    public override void ShowWindow()
    {
        base.ShowWindow();
        InitializeItems();

    }


    private void UpdateTabContent()
    {
        switch (_currentClotheType)
        {
            case ClotheType.Hair:
                _hairTabContent.SetActive(true);
                _torsoTabContent.SetActive(false);
                break;
            case ClotheType.Torso:
                _hairTabContent.SetActive(false);
                _torsoTabContent.SetActive(true);
                break;
        }

        foreach (var buttonHair in _hairItems)
        {
            buttonHair.UpdateButtonState();
        }

        foreach (var buttonTorso in _torsoItems)
        {
            buttonTorso.UpdateButtonState();
        }
        
    }

    private void InitializeItems()
    {
        InitializeItemsOfType(ClotheType.Hair, _hairItems);
        InitializeItemsOfType(ClotheType.Torso, _torsoItems);
    }

    private void InitializeItemsOfType(ClotheType clotheType, List<ItemClotheStore> items)
    {
        var typesItems = _itemStoreData.typesItems
            .Where(typesItem => typesItem.clotheType == clotheType)
            .SelectMany(typesItem => typesItem.items)
            .ToList();

        if (items.Count != typesItems.Count)
        {
            Debug.LogError("The number of ItemClotheStore objects and ItemData objects do not match for " + clotheType);
            return;
        }

        var pairedItems = items.Zip(typesItems, (item, itemData) => new {Item = item, ItemData = itemData});

        foreach (var pair in pairedItems)
        {
            int index = items.IndexOf(pair.Item);
            pair.Item.Initialize(pair.ItemData.itemID, pair.ItemData.itemSprite, pair.ItemData.itemPrice, clotheType, index);

        }

    }

    public void SetHairsColor(Color color)
    {
        foreach (var item in _hairItems)
        {
            item.SetColor(color);
            
            // if (!item.CanAfford()) return;
                
            ButtonOptimizedAnim buttonOptimizedAnim = item.GetComponent<ButtonOptimizedAnim>();
            buttonOptimizedAnim.GetTargetColors();
            // buttonOptimizedAnim.ResetNormalColor(Color.white);
        }
    }
        

   
}
public enum ClotheType
{

    Hair,
    Torso,
}