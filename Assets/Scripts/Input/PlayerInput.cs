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
        playerControls.Combat.Shoot.started += OnShoot;
        playerControls.Combat.Shoot.canceled += OnShoot;
        playerControls.Combat.AimDownSight.started += OnAim;
        playerControls.Combat.AimDownSight.canceled += OnAim;
        playerControls.Combat.Jump.started += OnJump;
        playerControls.Combat.Jump.canceled += OnJump;
        playerControls.Combat.Sprint.started += OnSprint;
        playerControls.Combat.Sprint.canceled += OnSprint;
    }

    private void PlayerCombatInputDisable()
    {
        playerControls.Combat.Shoot.started -= OnShoot;
        playerControls.Combat.Shoot.canceled -= OnShoot;
        playerControls.Combat.AimDownSight.started -= OnAim;
        playerControls.Combat.AimDownSight.canceled -= OnAim;
        playerControls.Combat.Jump.started -= OnJump;
        playerControls.Combat.Jump.canceled -= OnJump;
        playerControls.Combat.Sprint.started -= OnSprint;
        playerControls.Combat.Sprint.canceled -= OnSprint;
    }

    #endregion

    #region Events

    private void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }

    private void OnAim(InputAction.CallbackContext context)
    {
        isAiming = context.ReadValueAsButton();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.ReadValueAsButton();
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    #endregion
}
