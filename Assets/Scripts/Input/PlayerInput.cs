using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 movementVector = Vector2.zero;
    private Vector2 lookVector = Vector2.zero;
    private bool jumped = false;
    private bool isSprinting = false;
    private bool isAiming = false;
    private bool isShooting = false;

    public Vector2 MovementVector => movementVector;
    public Vector2 LookVector => lookVector;
    public bool Jumped => jumped;
    public bool IsSprinting => isSprinting;
    public bool IsAiming => isAiming;
    public bool IsShooting => isShooting;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Combat.Enable();
        PlayerCombatInputEnable();
    }

    private void OnDisable()
    {
        playerControls.Combat.Disable();
        PlayerCombatInputDisable();
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = focus;
    }

    private void Update()
    {
        if (playerControls.Combat.enabled)
        {
            movementVector = playerControls.Combat.Movement.ReadValue<Vector2>();
            lookVector = playerControls.Combat.Look.ReadValue<Vector2>();
        }
    }

    #region Setup

    private void PlayerCombatInputEnable()
    {
        playerControls.Combat.Shoot.performed += Shoot_performed;
        playerControls.Combat.Shoot.canceled += Shoot_canceled;
        playerControls.Combat.AimDownSight.performed += AimDownSight_performed;
        playerControls.Combat.AimDownSight.canceled += AimDownSight_canceled;
        playerControls.Combat.Jump.performed += Jump_performed;
        playerControls.Combat.Jump.canceled += Jump_canceled;
        playerControls.Combat.Sprint.performed += Sprint_performed;
        playerControls.Combat.Sprint.canceled += Sprint_canceled;
    }

    private void PlayerCombatInputDisable()
    {
        playerControls.Combat.Shoot.performed -= Shoot_performed;
        playerControls.Combat.Shoot.canceled -= Shoot_canceled;
        playerControls.Combat.AimDownSight.performed -= AimDownSight_performed;
        playerControls.Combat.AimDownSight.canceled -= AimDownSight_canceled;
        playerControls.Combat.Jump.performed -= Jump_performed;
        playerControls.Combat.Jump.canceled -= Jump_canceled;
        playerControls.Combat.Sprint.performed -= Sprint_performed;
        playerControls.Combat.Sprint.canceled -= Sprint_canceled;
    }

    #endregion

    #region Shoot Events

    private void Shoot_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isShooting = !isShooting;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }

    #endregion

    #region Aim Events

    private void AimDownSight_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isAiming = !isAiming;
    }

    private void AimDownSight_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isAiming = context.ReadValueAsButton();
    }

    #endregion

    #region Jump Events

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        jumped = !jumped;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        jumped = context.ReadValueAsButton();
    }

    #endregion

    #region Sprint Events

    private void Sprint_canceled(InputAction.CallbackContext context)
    {
        isSprinting = !isSprinting;
    }

    private void Sprint_performed(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    #endregion
}
