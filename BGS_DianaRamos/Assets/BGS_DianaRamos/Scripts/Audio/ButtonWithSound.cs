using System.Collections;
using System.Collections.Generic;
using DINO.Utility.Audio;
using UnityEngine;
using AudioType = UnityEngine.AudioType;

public class ButtonWithSound : MonoBehaviour
{
    [SerializeField] private string _audioName = "ButtonClick";

    private void Start()
    {
        if (AudioManager.Instance.IsInitialized)
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(PlaySound);
        }
        else
        {
            AudioManager.Instance.OnFinishedInitialize += () => GetComponent<UnityEngine.UI.Button>().onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySound(_audioName);
    }
}
