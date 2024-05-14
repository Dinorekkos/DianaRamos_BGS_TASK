using System;
using System.Collections;
using System.Collections.Generic;
using DINO.Utility.Audio;
using UnityEngine;

namespace DINO.Utility.Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region singleton
        private static AudioManager _instance;
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AudioManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = "AudioManager";
                        _instance = go.AddComponent<AudioManager>();
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region serialized fields

        [Header("Audio Manager Data")] 
        [SerializeField]
        private AudioManagerData _audioManagerData;

        [HideInInspector]
        [Header("Audio Test")]
        public string _soundNameTest;
        #endregion

        #region private fields
        
        private GameObject _soundsContainer;
        private List<AudioSource> _audioSources = new List<AudioSource>();
        
        private List<AudioData> _sfxAudioData = new List<AudioData>();
        private List<AudioData> _musicAudioData = new List<AudioData>();
        
        #endregion

        public AudioManagerData AudioManagerData
        {
            get => _audioManagerData;
            set => _audioManagerData = value;
        }
        
        public bool IsInitialized { get; private set; }

        public Action OnFinishedInitialize;

        #region unity methods
        private void Awake()
        {
            CreateInstance();
        }

        private void Start()
        {
            Initialize();
        }

        
        #endregion

        #region private methods
        private void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
        
        private AudioSource FindAudioSource(AudioClip clip)
        {
            return _audioSources.Find(x => x.clip == clip);
        }
        private void Initialize()
        {
            _soundsContainer = new GameObject("SoundsContainer");
            _audioSources = new List<AudioSource>();
            _soundsContainer.transform.SetParent(transform);
            PrepareLists();
            IsInitialized = true;
            OnFinishedInitialize?.Invoke();
        }

        
        private void  PrepareLists()
        {
            _sfxAudioData = _audioManagerData.audioData.FindAll(x => x.audioType == AudioType.SFX);
            _musicAudioData = _audioManagerData.audioData.FindAll(x => x.audioType == AudioType.Music);
        }

        #endregion

        
        #region public methdos
        public void PlaySound(string soundName)
        {
            AudioData audioData = _audioManagerData.audioData.Find(x => x.name == soundName);
            if (audioData == null)
            {
                Debug.LogWarning("Sound: " + soundName + " not found!");
                return;
            }
            
            AudioSource audioSource = FindAudioSource(audioData.clip);
            
            if (audioSource == null)
            {
                GameObject go = new GameObject("AS : " + audioData.name);
                audioSource =  go.AddComponent<AudioSource>();
                audioSource.transform.SetParent(_soundsContainer.transform);
                audioSource.clip = audioData.clip;
                audioSource.loop = audioData.loop;
                audioSource.volume = audioData.volume;
                audioSource.pitch = audioData.pitch;
                audioSource.Play();
                _audioSources.Add(audioSource);
            }
            else
            {
                audioSource.Play();
            }
            
            // Debug.Log("Playing sound: " + soundName);
        }
        
        public void StopSound(string soundName)
        {
            AudioData audioData = _audioManagerData.audioData.Find(x => x.name == soundName);
            if (audioData == null)
            {
                Debug.LogWarning("Sound: " + soundName + " not found!");
                return;
            }
            AudioSource audioSource = FindAudioSource(audioData.clip);
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }

        #endregion

        
        
    }
}