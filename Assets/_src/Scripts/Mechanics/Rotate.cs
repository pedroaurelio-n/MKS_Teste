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
        [SerializeField, Range(0f, 30f)] private float rotationSpeed = 5f;

        private float _rotationDirection;

        private Rigidbody2D _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        private void FixedUpdate() => AddTorque();

        private void AddTorque()
        {
            var torque = _rotationDirection * rotationSpeed;
            _rigidbody.AddTorque(torque);
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