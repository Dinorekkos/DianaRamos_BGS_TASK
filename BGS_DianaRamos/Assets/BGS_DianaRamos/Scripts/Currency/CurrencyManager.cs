using System;
using System.Collections;
using System.Collections.Generic;
using DINO.Utility.Audio;
using UnityEngine;

namespace DINO.TopDown2D.BSG
{
    public class CurrencyManager : MonoBehaviour
    {
        [SerializeField] private int initialCurrency = 0;
        [SerializeField] private RewardManager rewardManager;

        public int Currency { get; private set; }
        public static CurrencyManager Instance { get; private set; }

        public Action<int> OnCurrencyChanged;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            Currency = initialCurrency;
        }

        public bool CanAfford(int amount)
        {
            return Currency >= amount;
        }


        public void AddCurrency(int amount)
        {
            Currency += amount;
            OnCurrencyChanged?.Invoke(Currency);
            CountCoins();
            
            AudioManager.Instance.PlaySound(AudioKeys.COIN);
            
        }

        public void SpendCurrency(int amount)
        {
            if (Currency >= amount)
            {
                Currency -= amount;
                OnCurrencyChanged?.Invoke(Currency);
            }
        }
        
        public void CountCoins()
        {
            if(rewardManager != null)
                rewardManager.CountCoins();
        }
    }
}
