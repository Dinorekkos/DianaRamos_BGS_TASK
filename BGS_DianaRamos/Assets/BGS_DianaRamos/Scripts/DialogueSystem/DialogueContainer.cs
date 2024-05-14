using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DINO.TopDown2D.BSG
{
    [CreateAssetMenu(fileName = "DialogueContainer", menuName = "BGS/DialogueContainer", order = 0)]
    public class DialogueContainer : ScriptableObject
    {
        public List<Dialogue> dialogues;

        private void ResetDialogues()
        {
            foreach (var dialogue in dialogues)
            {
                dialogue.isEndDialogue = false;
            }
        }
        private void OnDisable()
        {
            ResetDialogues();
            
        }
    }

    [System.Serializable]
    public class Dialogue
    {
        public string dialogueID;
        public string characterName;
        public string Text;
        public string[] options;
        public string[] nextDialogues;
        public bool isEndDialogue;
    }

}