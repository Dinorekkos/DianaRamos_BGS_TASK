using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dino.TopDown2D
{
    public class InputManager : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private InputActionReference interactAction;
        #endregion

        #region public variables
        public static Vector2 MovementVector2; 
        public static Vector2 MousePosVector2;
        public static InputManager Instance { get; private set; }
        #endregion

        #region private variables

        private PlayerInput _playerInput;
        private InputAction _movementAction;
        
        public  InputActionReference InteractAction => interactAction;

        #endregion

        #region Unity Methods
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            _playerInput = GetComponent<PlayerInput>();
            _movementAction = _playerInput.actions["Movement"];
        }

        private void Update()
        {
            MovementVector2 = _movementAction.ReadValue<Vector2>();
        }
        

        #endregion
        
    }
    
}