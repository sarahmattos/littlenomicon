//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/InputManager.inputactions
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

public partial class @InputManager : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b38c0c7b-cf15-4fec-95ed-94a43d0908c8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d5d39374-afa3-4975-a7aa-a7a6fc8ac490"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""c535129a-9c63-494c-b9bd-664256a3bd04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jornal"",
                    ""type"": ""Button"",
                    ""id"": ""ad3fb260-8688-4356-a6a1-3d545e24d3e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""171f4ff2-4d5d-4225-b98c-7140f6f5154e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Voltar"",
                    ""type"": ""Button"",
                    ""id"": ""5f0c56f7-a03c-439b-a8c2-0f97a650ff35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Teste"",
                    ""type"": ""Button"",
                    ""id"": ""740cd113-41dc-42c7-9eb2-c107c81acafc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateMouse"",
                    ""type"": ""Button"",
                    ""id"": ""ea7e4214-cca9-4d11-8a10-250cc945181f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""9a5cc58d-7933-4b09-8c28-e4fad02e0b28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""85d5bf2a-b7ca-44a5-8385-0d8ccfba4a66"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b2777f4c-6314-41c4-8e43-29b754a97fdc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ac35d0d-c1d2-4d8a-9ff7-22998066125b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50cf7123-8f42-4ab1-9d71-48c9cc37df36"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5b92130-2679-4018-b2fb-a5bd0d7b00ed"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6427fa5b-d586-419f-a2e0-d5c53f1d376b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0c0ee36-61ed-4690-8f45-25152f6bd1eb"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""915211f8-8215-4d82-9ad7-c7ffe7bde488"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Voltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb2a9674-8caf-4462-b141-f8e45dbd5e32"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e7bf53f-24bb-4a61-b4ab-dcbb16275c88"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e2cf5cc-9e1a-4bd7-9d87-65af26fd5ccd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""289b705e-1d31-40b1-aacc-301b8fe7a21e"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jornal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Press = m_Player.FindAction("Press", throwIfNotFound: true);
        m_Player_Jornal = m_Player.FindAction("Jornal", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_Voltar = m_Player.FindAction("Voltar", throwIfNotFound: true);
        m_Player_Teste = m_Player.FindAction("Teste", throwIfNotFound: true);
        m_Player_RotateMouse = m_Player.FindAction("RotateMouse", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Press;
    private readonly InputAction m_Player_Jornal;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_Voltar;
    private readonly InputAction m_Player_Teste;
    private readonly InputAction m_Player_RotateMouse;
    private readonly InputAction m_Player_Dash;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Press => m_Wrapper.m_Player_Press;
        public InputAction @Jornal => m_Wrapper.m_Player_Jornal;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @Voltar => m_Wrapper.m_Player_Voltar;
        public InputAction @Teste => m_Wrapper.m_Player_Teste;
        public InputAction @RotateMouse => m_Wrapper.m_Player_RotateMouse;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Jornal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJornal;
                @Jornal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJornal;
                @Jornal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJornal;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Voltar.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVoltar;
                @Voltar.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVoltar;
                @Voltar.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVoltar;
                @Teste.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTeste;
                @Teste.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTeste;
                @Teste.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTeste;
                @RotateMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateMouse;
                @RotateMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateMouse;
                @RotateMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateMouse;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @Jornal.started += instance.OnJornal;
                @Jornal.performed += instance.OnJornal;
                @Jornal.canceled += instance.OnJornal;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Voltar.started += instance.OnVoltar;
                @Voltar.performed += instance.OnVoltar;
                @Voltar.canceled += instance.OnVoltar;
                @Teste.started += instance.OnTeste;
                @Teste.performed += instance.OnTeste;
                @Teste.canceled += instance.OnTeste;
                @RotateMouse.started += instance.OnRotateMouse;
                @RotateMouse.performed += instance.OnRotateMouse;
                @RotateMouse.canceled += instance.OnRotateMouse;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnJornal(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnVoltar(InputAction.CallbackContext context);
        void OnTeste(InputAction.CallbackContext context);
        void OnRotateMouse(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
