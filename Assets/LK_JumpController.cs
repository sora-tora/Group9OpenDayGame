using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.Logan.MinigameRun
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LK_JumpController : MonoBehaviour
    {
        // based on https://github.com/loganator956/Character-Systems/blob/master/Assets/Character%20Systems/Scripts/CharacterMovement3D.cs
        public KeyCode JumpCode = KeyCode.W;

        public float JumpForce = 10f;
        public float JumpForceDegradation = 10f;

        private const float GravityAcceleration = 9.8f;
        private const float TermianlFallVelocity = 10f;

        private bool _isJumpKeyPressed = false;

        private float _moveY = 0f;
        private float _currentJumpForce = 0f;

        private bool _isGrounded = false;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            _isGrounded = Physics2D.Raycast(transform.position + Vector3.down * 0.505f, Vector3.down, 0.01f);
            _isJumpKeyPressed = Input.GetKey(JumpCode);
            if (Input.GetKeyDown(JumpCode) && CheckCanJump())
            {
                _currentJumpForce = JumpForce;
            }

            // gravity
            if (!_isGrounded)
            {
                _moveY -= GravityAcceleration * Time.deltaTime;
                _moveY = Mathf.Clamp(_moveY, -TermianlFallVelocity, TermianlFallVelocity);
            }
            else
            {
                _moveY = 0f;
            }

            // jumping
            if (_currentJumpForce > 0f)
            {
                if (!_isJumpKeyPressed)
                {
                    // cancel jump, take away much quicker
                    _currentJumpForce -= JumpForceDegradation * 2 * Time.deltaTime;
                }
                else
                {
                    _currentJumpForce -= JumpForceDegradation * Time.deltaTime;
                }
                _moveY = _currentJumpForce;
            }
        }

        private void FixedUpdate()
        {
            Vector3 velocity = _rb.velocity;
            velocity.y = _moveY;
            _rb.velocity = velocity;
        }

        bool CheckCanJump()
        {
            return _isGrounded;
        }
    }
}