using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DINO.Utility.Audio;
using UnityEngine;

namespace DINO.TopDown2D.BSG
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _instance;

        public static DialogueManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<DialogueManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = "DialogueManager";
                        _instance = go.AddComponent<DialogueManager>();
                    }
                }

                return _instance;
            }
        }
        
        public Action<Dialogue> OnDialogueStart;

        private void Awake()
        {
            _instance = this;
        }

        void Start()
        {

        }

        public void StartDialogue(DialogueContainer dialogueContainer)
        {
            Dialogue dialogue = null;
            bool allDialoguesRead = dialogueContainer.dialogues.All(d => d.isEndDialogue);

            if (allDialoguesRead)
            {
                dialogue = dialogueContainer.dialogues.LastOrDefault();
            }
            else
            {
                dialogue = dialogueContainer.dialogues.FirstOrDefault(d => !d.isEndDialogue);
            }

            OnDialogueStart?.Invoke(dialogue);

            if (dialogue != null)
            {
                dialogue.isEndDialogue = true;
            }
            
            AudioManager.Instance.PlaySound(AudioKeys.SPEAK);
        }
    }
}
