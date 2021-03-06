// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""befc3673-eedc-4ded-a70d-12da794c3963"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""50a26a1c-f977-45f5-83c1-dcd5dba3decc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""92ea497a-5a9d-4925-aed0-995ff778ce9a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""c3a58551-6f7a-4ca3-8958-72fa7696b433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4d709ffe-30c3-44e3-94ef-972f98bce654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDownSight"",
                    ""type"": ""Button"",
                    ""id"": ""ff8881de-6924-4b74-843a-b7fdd43ba646"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""18c41e02-3fe3-48d6-b3f4-9651450e9e23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""5fb74a39-e4d1-471a-a8b9-ab231477648f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""10026345-d063-42ec-8381-6bab78fe96bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""8b9e69df-317d-4398-a1df-c84aec91bb66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""8e5ef6a9-843d-4d7e-81a3-8038ee0ccd8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a636f1d5-5370-4269-bd59-336a4fecb40a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""31cc76ec-dbe2-41f8-b7bb-ef9ef007d324"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a0c49726-77ef-4d1e-99aa-bd32179a8087"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9fd4cebf-9003-40ef-a742-48ce1301e20e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""19fdb6d1-f4d3-49b2-8a73-05c0d63bb018"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c90dcb4a-7244-4cba-8291-fb396ebce98f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46e88faf-6395-4d21-ae21-ca3e1cd268bc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=15,y=15)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d6a2f79-432f-424a-939b-cc471d7b2e8b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=300,y=300)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a4ae746-12cd-4272-805a-db5b91cada13"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75d66768-0bea-4232-b068-df33b7a265a5"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faa0b34b-4f91-4b34-919d-8a42faad7a87"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eac6038c-e7e5-4664-92d6-dd33227c9d33"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19fd7229-d826-4ff0-b4fa-9f078703d025"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownSight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf4919ed-df9b-4b6a-8d65-7345ed1852d6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDownSight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b40e19d-87f2-4e03-b335-3c7c7ed6bcaa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b4cdbc9-8b74-43cd-9122-8b16f08ba273"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b3d0015-7400-4e7b-af4b-567d8bbffe59"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d250667-30d9-4e33-9fe2-adf7072296ca"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bedbd76b-2950-4fe5-8620-15b3e9b9dde2"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b021f8b9-4c91-4251-8173-e13c7760a8b9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b30f5755-4501-4cd4-9513-6c3d6dc1bb56"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ada2a00-014a-4708-bf34-f35ad77b63db"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f8b5254-46af-4a2a-8ce5-781382282ab3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3042645b-b53b-47bd-b932-3eca8c077082"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b1b3f88-9c08-43bb-8eed-74256a37c332"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Building"",
            ""id"": ""dcaada00-c82b-4aa6-a853-a7b3deb36bb1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a48d04ef-9693-4cfd-969e-7ee7c8b2e97d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""1b0a1132-86ed-4219-bee3-236251a0b41a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""6dea8888-ae12-4fdd-a4a6-4376a32708dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f06650c7-c89e-4d2f-acc0-d8e2ce5190a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""850e2416-9589-47ee-ad92-b41cb879a300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cba19047-3e53-47d9-b829-f16bc2b55773"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bda3324d-78e8-4d6e-b413-30ded4bb82c3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=15,y=15)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e8d4c46-de35-4fdd-93b0-8e77b6d6432d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=300,y=300)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0707ddfd-1635-4660-9c01-977d803b304a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""927266ac-0c54-42c0-ac0a-5f66ff7bd32a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4842ea0-566b-4556-84fa-d0e46c2710e3"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d6bcd45-defa-420b-b1e2-a09650aec4f5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e58e09b-dd3a-44ff-8326-a2b25c21946c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4d8ccc5-3ea4-4d9d-8a3f-a22be79eef7c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""705b693d-d588-4296-b59d-62697ceefa42"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45855f5a-65b1-4dbf-894f-5c90ecb84f42"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c893447-87ac-4ef3-80df-81ad91a3f91f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""79159afe-ba90-4f8a-a458-42f79b7c2a6c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""04b3d86f-8a18-4866-a6af-778109503c22"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6e69541d-0c6e-4248-87be-ce649efb08fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4057e514-53ce-4c82-9dc7-b0a5b293bf87"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""75eed8e9-13b3-44b5-bbf5-8c0f240074f9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a49b0f7b-566b-49d4-b792-4133920a6140"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Movement = m_Combat.FindAction("Movement", throwIfNotFound: true);
        m_Combat_Look = m_Combat.FindAction("Look", throwIfNotFound: true);
        m_Combat_Sprint = m_Combat.FindAction("Sprint", throwIfNotFound: true);
        m_Combat_Shoot = m_Combat.FindAction("Shoot", throwIfNotFound: true);
        m_Combat_AimDownSight = m_Combat.FindAction("AimDownSight", throwIfNotFound: true);
        m_Combat_Jump = m_Combat.FindAction("Jump", throwIfNotFound: true);
        m_Combat_Build = m_Combat.FindAction("Build", throwIfNotFound: true);
        m_Combat_Reload = m_Combat.FindAction("Reload", throwIfNotFound: true);
        m_Combat_Cancel = m_Combat.FindAction("Cancel", throwIfNotFound: true);
        m_Combat_Menu = m_Combat.FindAction("Menu", throwIfNotFound: true);
        // Building
        m_Building = asset.FindActionMap("Building", throwIfNotFound: true);
        m_Building_Movement = m_Building.FindAction("Movement", throwIfNotFound: true);
        m_Building_Look = m_Building.FindAction("Look", throwIfNotFound: true);
        m_Building_Confirm = m_Building.FindAction("Confirm", throwIfNotFound: true);
        m_Building_Cancel = m_Building.FindAction("Cancel", throwIfNotFound: true);
        m_Building_Build = m_Building.FindAction("Build", throwIfNotFound: true);
        m_Building_Jump = m_Building.FindAction("Jump", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Movement;
    private readonly InputAction m_Combat_Look;
    private readonly InputAction m_Combat_Sprint;
    private readonly InputAction m_Combat_Shoot;
    private readonly InputAction m_Combat_AimDownSight;
    private readonly InputAction m_Combat_Jump;
    private readonly InputAction m_Combat_Build;
    private readonly InputAction m_Combat_Reload;
    private readonly InputAction m_Combat_Cancel;
    private readonly InputAction m_Combat_Menu;
    public struct CombatActions
    {
        private @PlayerControls m_Wrapper;
        public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Combat_Movement;
        public InputAction @Look => m_Wrapper.m_Combat_Look;
        public InputAction @Sprint => m_Wrapper.m_Combat_Sprint;
        public InputAction @Shoot => m_Wrapper.m_Combat_Shoot;
        public InputAction @AimDownSight => m_Wrapper.m_Combat_AimDownSight;
        public InputAction @Jump => m_Wrapper.m_Combat_Jump;
        public InputAction @Build => m_Wrapper.m_Combat_Build;
        public InputAction @Reload => m_Wrapper.m_Combat_Reload;
        public InputAction @Cancel => m_Wrapper.m_Combat_Cancel;
        public InputAction @Menu => m_Wrapper.m_Combat_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnLook;
                @Sprint.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnSprint;
                @Shoot.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
                @AimDownSight.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnAimDownSight;
                @AimDownSight.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnAimDownSight;
                @AimDownSight.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnAimDownSight;
                @Jump.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                @Build.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnBuild;
                @Reload.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnReload;
                @Cancel.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnCancel;
                @Menu.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AimDownSight.started += instance.OnAimDownSight;
                @AimDownSight.performed += instance.OnAimDownSight;
                @AimDownSight.canceled += instance.OnAimDownSight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);

    // Building
    private readonly InputActionMap m_Building;
    private IBuildingActions m_BuildingActionsCallbackInterface;
    private readonly InputAction m_Building_Movement;
    private readonly InputAction m_Building_Look;
    private readonly InputAction m_Building_Confirm;
    private readonly InputAction m_Building_Cancel;
    private readonly InputAction m_Building_Build;
    private readonly InputAction m_Building_Jump;
    public struct BuildingActions
    {
        private @PlayerControls m_Wrapper;
        public BuildingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Building_Movement;
        public InputAction @Look => m_Wrapper.m_Building_Look;
        public InputAction @Confirm => m_Wrapper.m_Building_Confirm;
        public InputAction @Cancel => m_Wrapper.m_Building_Cancel;
        public InputAction @Build => m_Wrapper.m_Building_Build;
        public InputAction @Jump => m_Wrapper.m_Building_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Building; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildingActions set) { return set.Get(); }
        public void SetCallbacks(IBuildingActions instance)
        {
            if (m_Wrapper.m_BuildingActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnLook;
                @Confirm.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnCancel;
                @Build.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnBuild;
                @Jump.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_BuildingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public BuildingActions @Building => new BuildingActions(this);
    public interface ICombatActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAimDownSight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface IBuildingActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
