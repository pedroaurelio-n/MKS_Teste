//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/InputSystem/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PedroAurelio.MKS
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""965e91e9-8094-4b59-8542-ee6c7e243afa"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""db8016c5-7f4b-4e63-b52f-16b8409a6254"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""323ec018-b5bd-4680-845c-9d9685cf2c8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootFront"",
                    ""type"": ""Button"",
                    ""id"": ""23ffc6b2-0556-40d3-b34c-91a325f80645"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootSide"",
                    ""type"": ""Button"",
                    ""id"": ""e63a438e-d233-41dc-a5f4-a4a68713c21f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ad0aba9-93a1-4df5-8bfd-1caed433fb0a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left-Right Axis"",
                    ""id"": ""7583a57d-ca9b-4a67-ac85-66437951f049"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a828391e-85c2-4000-882a-60a08f2f87f7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e94cd7b1-f9b7-4bff-8a5d-340f0505c792"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c8ea6cb-caa1-4140-a5b2-c0b57517f050"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc325e58-dd13-45a9-97e3-69495fce81d4"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootSide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Forward = m_Gameplay.FindAction("Forward", throwIfNotFound: true);
            m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
            m_Gameplay_ShootFront = m_Gameplay.FindAction("ShootFront", throwIfNotFound: true);
            m_Gameplay_ShootSide = m_Gameplay.FindAction("ShootSide", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Forward;
        private readonly InputAction m_Gameplay_Rotate;
        private readonly InputAction m_Gameplay_ShootFront;
        private readonly InputAction m_Gameplay_ShootSide;
        public struct GameplayActions
        {
            private @PlayerControls m_Wrapper;
            public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Forward => m_Wrapper.m_Gameplay_Forward;
            public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
            public InputAction @ShootFront => m_Wrapper.m_Gameplay_ShootFront;
            public InputAction @ShootSide => m_Wrapper.m_Gameplay_ShootSide;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Forward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                    @Forward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                    @Forward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                    @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                    @ShootFront.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootFront;
                    @ShootFront.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootFront;
                    @ShootFront.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootFront;
                    @ShootSide.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootSide;
                    @ShootSide.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootSide;
                    @ShootSide.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootSide;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Forward.started += instance.OnForward;
                    @Forward.performed += instance.OnForward;
                    @Forward.canceled += instance.OnForward;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @ShootFront.started += instance.OnShootFront;
                    @ShootFront.performed += instance.OnShootFront;
                    @ShootFront.canceled += instance.OnShootFront;
                    @ShootSide.started += instance.OnShootSide;
                    @ShootSide.performed += instance.OnShootSide;
                    @ShootSide.canceled += instance.OnShootSide;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        public interface IGameplayActions
        {
            void OnForward(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnShootFront(InputAction.CallbackContext context);
            void OnShootSide(InputAction.CallbackContext context);
        }
    }
}
