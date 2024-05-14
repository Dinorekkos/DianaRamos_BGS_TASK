using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    [SerializeField] private GameObject _mineEffect;

    private TimerBase _timer;
    
    protected override void Initialize()
    {
        base.Initialize();
        _timer = gameObject.AddComponent<TimerBase>();
        _timer.OnTimerEnd += OnTimerEnd;
        _timer.OnTimerUpdate += UpdateSlider;
        _timer.OnTimerStart += OnTimerStart;
        
        SetSlider();
        _slider.gameObject.SetActive(false);
        _mineEffect.SetActive(false);
    }

    protected override void Interact()
    {
        if(InteractionsManager.Instance.CurrentInteractionObject != this) return;
        if(_timer.IsTimerActive) return;
        base.Interact();
        _slider.gameObject.SetActive(true);
        _timer.StartTimer(_timeToMine, "", true);
        _mineEffect.SetActive(true);
        
        // Debug.Log("Interacting with Gem Mine");
    }
    
    protected override void OnCanInteract()
    {
        if(_timer.IsTimerActive) return;
        notification.SetActive(false);
        base.OnCanInteract();
    }

    protected override void OnStopInteracting()
    {
        base.OnStopInteracting();
        
        if(_timer.IsTimerActive) return;
        notification.SetActive(true);
    }

    private void SetSlider()
    {
        _slider.maxValue = _timeToMine + 1;
        _slider.value = _timeToMine;
    }

    private void OnTimerEnd()
    {
        _slider.gameObject.SetActive(false);
        CurrencyManager.Instance.AddCurrency(_gemsToMine);
        notification.SetActive(true);
        _timer.StopTimer();
        _mineEffect.SetActive(false);

    }
    
    private void OnTimerStart()
    {
        _slider.gameObject.SetActive(true);
        notification.SetActive(false);
        SetSlider();
    }

    private void UpdateSlider(float time)
    {
        _slider.value = time - 1;
    }
}
