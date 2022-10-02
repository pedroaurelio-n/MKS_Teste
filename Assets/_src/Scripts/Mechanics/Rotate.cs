using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rotate : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(20f, 200f)] private float rotationSpeed = 60f;
        [SerializeField, Range(0f, 10f)] private float posAccel = 4f;
        [SerializeField, Range(0f, 10f)] private float negAccel = 2.5f;

        private float _rotationDirection;

        private Rigidbody2D _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        private void FixedUpdate() => AddTorque();

        private void AddTorque()
        {
            if (_rotationDirection != 0f)
                _rigidbody.angularVelocity = Mathf.MoveTowards(_rigidbody.angularVelocity, rotationSpeed * _rotationDirection, posAccel);
            else
                _rigidbody.angularVelocity = Mathf.MoveTowards(_rigidbody.angularVelocity, 0f, negAccel);

            Debug.Log(_rigidbody.angularVelocity);
        }

        public void SetRotationDirection(float direction) => _rotationDirection = direction;
        
        public void SetRotationDirection(InputAction.CallbackContext ctx)
        {
            switch (ctx.phase)
            {
                case InputActionPhase.Performed: SetRotationDirection(ctx.ReadValue<float>()); break;
                case InputActionPhase.Canceled: SetRotationDirection(0f); break;
                default: break;
            }
        }
    }
}