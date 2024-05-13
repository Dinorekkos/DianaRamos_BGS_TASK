using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DINO.TopDown2D.BSG;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _currencyText;
    [SerializeField] private GameObject _currencyIcon;
    void Start()
    {
        UpdateCurrencyText(CurrencyManager.Instance.Currency);
        CurrencyManager.Instance.OnCurrencyChanged += UpdateCurrencyText; 
    }

    private void UpdateCurrencyText(int currency)
    {
        _currencyText.text = currency.ToString();
        _currencyText.transform.DOShakeScale(0.5f, 0.2f, 10, 90, false).SetLoops(1, LoopType.Yoyo);
        _currencyIcon.transform.DOShakeScale(0.5f, 0.2f, 10, 90, false).SetLoops(1, LoopType.Yoyo);
    }

}
