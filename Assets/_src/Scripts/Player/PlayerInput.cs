using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MKS
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(Rotate))]
    public class PlayerInput : MonoBehaviour
    {
        private MoveForward _move;
        private Rotate _rotate;

        private PlayerControls _controls;

        private void Awake()
        {
            _move = GetComponent<MoveForward>();
            _rotate = GetComponent<Rotate>();
        }

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new PlayerControls();

                _controls.Gameplay.Forward.performed += _move.SetForwardInput;
                _controls.Gameplay.Forward.canceled += _move.SetForwardInput;

                _controls.Gameplay.Rotate.performed += _rotate.SetRotationDirection;
                _controls.Gameplay.Rotate.canceled += _rotate.SetRotationDirection;

                _controls.Enable();
            }
        }

        private void OnDisable()
        {
            _controls.Gameplay.Forward.performed -= _move.SetForwardInput;
            _controls.Gameplay.Forward.canceled -= _move.SetForwardInput;

            _controls.Gameplay.Rotate.performed -= _rotate.SetRotationDirection;
            _controls.Gameplay.Rotate.canceled -= _rotate.SetRotationDirection;

            _controls.Disable();
        }
    }
}