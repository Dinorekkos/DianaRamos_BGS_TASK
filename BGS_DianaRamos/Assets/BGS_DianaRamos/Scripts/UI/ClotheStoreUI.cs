using System.Collections;
using System.Collections.Generic;
using DINO.Utility;
using UnityEngine;
using UnityEngine.UI;

public class ClotheStoreUI : MenuWindow
{
    
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _hairTab;
    [SerializeField] private Button _torsoTab;
    
    [SerializeField] private GameObject _hairTabContent;
    [SerializeField] private GameObject _torsoTabContent;
    
    private ClotheType _currentClotheType;
    protected override void Initialize()
    {
        base.Initialize();
        // _closeButton.OnClick += CloseWindow;
        
        _hairTab.onClick.AddListener(() => ChangeTab(ClotheType.Hair));
        _torsoTab.onClick.AddListener(() => ChangeTab(ClotheType.Torso));
        
    }

    private void ChangeTab(ClotheType clotheType)
    {
        _currentClotheType = clotheType;
        UpdateTabContent();
       
    }
    
    public override void ShowWindow()
    {
        base.ShowWindow();
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
    }

}

public enum ClotheType
{
    
    Hair,
    Torso,
    // Legs,
    // Shoes
}