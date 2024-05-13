using System;
using System.Collections;
using System.Collections.Generic;
using Dino.TopDown2D;
using UnityEngine;

namespace DINO.TopDown2D.BSG
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Singleton

        private static PlayerMovement _instance;
        
        public static PlayerMovement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerMovement>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = "PlayerMovement";
                        _instance = go.AddComponent<PlayerMovement>();
                    }
                }

                return _instance;
            }
        }
        

        #endregion
        
        #region SerializaedFields

        [SerializeField] private float _moveSpeed = 5f;
        
        #endregion

        #region private Variables

        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementVector2;

        private Animator _animator;
        private string _horizontalAnim = "Horizontal";
        private string _verticalAnim = "Vertical";
       
        private bool _isMoving;
        private bool _canMove = true;
        
        #endregion

        private void Awake()
        {
            _instance = this;
        }

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            if (!_canMove) return;
            
            _movementVector2.Set(InputManager.MovementVector2.x, InputManager.MovementVector2.y);
            _rigidbody2D.velocity = _movementVector2 * _moveSpeed;
            
            if (_movementVector2 != Vector2.zero)
            {
                _animator.SetFloat(_horizontalAnim, _movementVector2.x);
                _animator.SetFloat(_verticalAnim, _movementVector2.y);
            }
            
            _isMoving = _movementVector2 != Vector2.zero;
            _animator.SetBool("Moving", _isMoving);

        }
        
        public void EnableMovement(bool enable)
        {
            _canMove = enable;
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("Moving", false);
        }
        public void SetAnimToFixedDirection(Vector2 direction)
        {
            _animator.SetFloat(_horizontalAnim, direction.x);
            _animator.SetFloat(_verticalAnim, direction.y);
        }
        
    }
}
