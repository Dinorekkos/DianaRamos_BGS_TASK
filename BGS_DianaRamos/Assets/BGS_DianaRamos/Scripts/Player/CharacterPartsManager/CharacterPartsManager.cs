using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartsManager : MonoBehaviour
{

    #region Serialized Fields
    [Header("Character Body")]
    [SerializeField] private CharacterBodyData characterBodyData;
    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;
    #endregion

    
    #region private variables
    
    private Animator _animator;
    private AnimationClip _animationClip;
    private AnimatorOverrideController _animatorOverrideController;
    private AnimationClipOverrides _defaultAnimationClips;

    #endregion
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        _animator.runtimeAnimatorController = _animatorOverrideController;
        
        SetBodyParts();
    }

    #region public methods
    public void SetBodyParts()
    {
        // Override default animation clips with character body parts
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            // Get current body part
            string partType = bodyPartTypes[partIndex];
            // Get current body part ID
            string partID = characterBodyData.characterBodyParts[partIndex].bodyPart.BodyPartAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    // Get players animation from player body
                    // ***NOTE: Unless Changed Here, Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    _animationClip = Resources.Load<AnimationClip>("Player Animations/" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);

                    // Override default animation
                    _defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = _animationClip;
                }
            }
        }
    }
    
    #endregion
    
    private class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}


