using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveForward : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0f, 10f)] private float moveSpeed = 1f;
        [SerializeField, Range(0f, 15f)] private float maxSpeed = 5f;
        [SerializeField, Range(0f, 20f)] private float posAccel = 5f;
        [SerializeField, Range(0f, 20f)] private float negAccel = 10f;

        private bool _forwardInput;

        private Rigidbody2D _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        private void FixedUpdate() => Move();

        private void Move()
        {
            Vector2 targetSpeed;
            float acceleration;

            if (_forwardInput)
            {
                targetSpeed = transform.right * moveSpeed;
                acceleration = posAccel;
            }
            else
            {
                targetSpeed = -_rigidbody.velocity;
                acceleration = negAccel;
            }

            _rigidbody.AddForce(acceleration * targetSpeed);

            var clampedVelocity = Vector2.ClampMagnitude(_rigidbody.velocity, maxSpeed);
            _rigidbody.velocity = clampedVelocity;
        }

        public void SetForwardInput(bool value) => _forwardInput = value;

        public void SetForwardInput(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed: SetForwardInput(true); break;
                case InputActionPhase.Canceled: SetForwardInput(false); break;
                default: break;
            }
        }
    }
}