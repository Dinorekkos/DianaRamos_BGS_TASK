using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DINO.TopDown2D.BSG
{
    public class RewardManager : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private GameObject pileOfCoins;
        [SerializeField] private Vector2 finalPos;
        [SerializeField] private float duration = 0.8f;
        [SerializeField] private TextMeshProUGUI counter;
        [SerializeField] private int coinsAmount;
        [SerializeField] private int coinsAnimCount;
        #endregion

        #region private variables
        private Vector2[] initialPos;
        private Quaternion[] initialRotation;
        #endregion

        void Start()
        {
            if (coinsAmount == 0)
            {
                Debug.LogError("Coins amount is not set");
                return;
            }
            
            Initialize();
        }

        private void Initialize()
        {
            initialPos = new Vector2[coinsAmount];
            initialRotation = new Quaternion[coinsAmount];
        
            for (int i = 0; i < pileOfCoins.transform.childCount; i++)
            {
                initialPos[i] = pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                initialRotation[i] = pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().rotation;
            }
        }
        
        private void ResetCoins()
        {
            
            for (int i = 0; i < pileOfCoins.transform.childCount; i++)
            {
                pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = initialPos[i];
                pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().rotation = initialRotation[i];
                pileOfCoins.transform.GetChild(i).localScale = Vector3.zero;
            }
            pileOfCoins.SetActive(false);
        }

        public void CountCoins()
        {
            if (coinsAmount == 0)
            {
                Debug.LogError("Coins amount is not set");
                return;
            }
            
            ResetCoins();
            pileOfCoins.SetActive(true);
            var delay = 0f;
        
            for (int i = 0; i < pileOfCoins.transform.childCount; i++)
            {
                pileOfCoins.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
                pileOfCoins.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(finalPos.x, finalPos.y), duration).SetDelay(delay + 0.5f).SetEase(Ease.InBack);
                pileOfCoins.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f).SetEase(Ease.Flash);
                pileOfCoins.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);
                delay += 0.1f;
                counter.transform.parent.GetChild(0).transform.DOScale(1.1f, 0.1f).SetLoops(10,LoopType.Yoyo).SetEase(Ease.InOutSine).SetDelay(1.2f);
            }

        }
    

    }

}