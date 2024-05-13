using System.Collections;
using System.Collections.Generic;
using Dino.TopDown2D;
using UnityEngine;

namespace Dino.TopDown2D
{
    public class PlayerMovement : MonoBehaviour
    {
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
        
        private void EnableMovement(bool enable)
        {
            _canMove = enable;
        }
       
    }
}
