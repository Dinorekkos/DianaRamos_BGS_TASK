using System.Collections;
using System.Collections.Generic;
using DINO.Utility.Audio;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    [SerializeField] private string _musicName = "MainMusic";
    void Start()
    {
        if (AudioManager.Instance.IsInitialized)
        {
            AudioManager.Instance.PlaySound(_musicName);

        }else
        {
            AudioManager.Instance.OnFinishedInitialize += () => AudioManager.Instance.PlaySound(_musicName);
        }

    }
}
