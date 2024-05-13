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
        if(_timer.IsTimerActive) return;
        base.Interact();
        _slider.gameObject.SetActive(true);
        _timer.StartTimer(_timeToMine, "", true);
        
        Debug.Log("Interacting with Gem Mine");
    }

    protected override void Initialize()
    {
        base.Initialize();
        _timer = gameObject.AddComponent<TimerBase>();
        _timer.OnTimerEnd += OnTimerEnd;
        _timer.OnTimerUpdate += UpdateSlider;
        _timer.OnTimerStart += OnTimerStart;
        
        SetSlider();
        // notification.SetActive(false);
        _slider.gameObject.SetActive(false);
    }

    private void SetSlider()
    {
        _slider.maxValue = _timeToMine;
        _slider.value = _timeToMine;
    }

    private void OnTimerEnd()
    {
        _slider.gameObject.SetActive(false);
        CurrencyManager.Instance.AddCurrency(_gemsToMine);
        _timer.StopTimer();
    }
    
    private void OnTimerStart()
    {
        _slider.gameObject.SetActive(true);
        SetSlider();
    }

    private void UpdateSlider(float time)
    {
        _slider.value = time;
    }
}
