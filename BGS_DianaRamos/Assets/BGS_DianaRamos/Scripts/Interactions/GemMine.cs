using System.Collections;
using System.Collections.Generic;
using DINO.TopDown2D.BSG;
using DINO.Utility;
using UnityEngine;
using UnityEngine.UI;

public class GemMine : InteractionObject
{
    [SerializeField] private GameObject notification;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _timeToMine = 5;
    [SerializeField] private int _gemsToMine = 1;

    private TimerBase _timer;
    protected override void Interact()
    {
        if(InteractionsManager.Instance.CurrentInteractionObject != this) return;
        base.Interact();
        _slider.gameObject.SetActive(true);
        _timer.StartTimer(_timeToMine);
        
        Debug.Log("Interacting with Gem Mine");
    }

    protected override void Initialize()
    {
        base.Initialize();
        _timer = gameObject.AddComponent<TimerBase>();
        _timer.OnTimerEnd += OnTimerEnd;
    }

    private void OnTimerEnd()
    {
        _slider.gameObject.SetActive(false);
        CurrencyManager.Instance.AddCurrency(_gemsToMine);
    }
}
