using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHairButton : MonoBehaviour
{
    [SerializeField] private ClotheStoreUI _clotheStoreUI;
    [SerializeField] Color _colorHair;
    [SerializeField] private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeColorHair);
    }
    
    private void ChangeColorHair()
    {
        _clotheStoreUI.SetHairsColor(_colorHair);
    }

}
