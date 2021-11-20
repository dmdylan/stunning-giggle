using System;
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
    private bool isReloading = false;
    private bool isBuilding = false;
    private bool didMenu = false;
    private bool didCancel = false;
    private bool didConfirm = false;

    public Vector2 MovementVector => movementVector;
    public Vector2 LookVector => lookVector;
    public bool Jumped => jumped;
    public bool IsSprinting => isSprinting;
    public bool IsAiming => isAiming;
    public bool IsShooting => isShooting;
    public bool IsReloading => isReloading;
    public bool IsBuilding => isBuilding;
    public bool DidMenu => didMenu;
    public bool DidCancel => didCancel;
    public bool DidConfirm => didConfirm;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Combat.Enable();
        PlayerCombatInputEnable();
        PlayerBuildInputEnable();
    }

    private void OnDisable()
    {
        if (playerControls.Combat.enabled)
            playerControls.Combat.Disable();
        else if(playerControls.Building.enabled)
            playerControls.Building.Disable();

        PlayerCombatInputDisable();
        PlayerBuildInputDisable();
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
        else if (playerControls.Building.enabled)
        {
            movementVector = playerControls.Building.Movement.ReadValue<Vector2>();
            lookVector = playerControls.Building.Look.ReadValue<Vector2>();
        }
    }

    public void ToggleCombatActionMap()
    {
        if (playerControls.Combat.enabled)
            playerControls.Combat.Disable();
        else
            playerControls.Combat.Enable();
    }

    public void ToggleBuildActionMap()
    {
        if (playerControls.Building.enabled)
            playerControls.Building.Disable();
        else
            playerControls.Building.Enable();
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
        playerControls.Combat.Reload.started += OnReload;
        playerControls.Combat.Reload.canceled += OnReload;
        playerControls.Combat.Build.started += OnBuild;
        playerControls.Combat.Build.canceled += OnBuild;
        playerControls.Combat.Cancel.started += OnCancel;
        playerControls.Combat.Cancel.canceled += OnCancel;
        playerControls.Combat.Menu.started += OnMenu;
        playerControls.Combat.Menu.canceled += OnMenu;
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
        playerControls.Combat.Reload.started -= OnReload;
        playerControls.Combat.Reload.canceled -= OnReload;
        playerControls.Combat.Build.started -= OnBuild;
        playerControls.Combat.Build.canceled -= OnBuild;
        playerControls.Combat.Cancel.started -= OnCancel;
        playerControls.Combat.Cancel.canceled -= OnCancel;
        playerControls.Combat.Menu.started -= OnMenu;
        playerControls.Combat.Menu.canceled -= OnMenu;
    }

    private void PlayerBuildInputEnable()
    {
        playerControls.Building.Confirm.started += OnConfirm;
        playerControls.Building.Confirm.canceled += OnConfirm;
        playerControls.Building.Cancel.started += OnCancel;
        playerControls.Building.Cancel.canceled += OnCancel;
        playerControls.Building.Build.started += OnBuild;
        playerControls.Building.Build.canceled += OnBuild;
        playerControls.Building.Jump.started += OnJump;
        playerControls.Building.Jump.canceled += OnJump;
    }

    private void PlayerBuildInputDisable()
    {
        playerControls.Building.Confirm.started -= OnConfirm;
        playerControls.Building.Confirm.canceled -= OnConfirm;
        playerControls.Building.Cancel.started -= OnCancel;
        playerControls.Building.Cancel.canceled -= OnCancel;
        playerControls.Building.Build.started -= OnBuild;
        playerControls.Building.Build.canceled -= OnBuild;
        playerControls.Building.Jump.started -= OnJump;
        playerControls.Building.Jump.canceled -= OnJump;
    }

    #endregion

    #region General Events

    private void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.ReadValueAsButton();
    }

    private void OnMenu(InputAction.CallbackContext context)
    {
        didMenu = context.ReadValueAsButton();
    }

    #endregion

    #region Combat Action Map Events

    private void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.ReadValueAsButton();
    }

    private void OnAim(InputAction.CallbackContext context)
    {
        isAiming = context.ReadValueAsButton();
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    private void OnBuild(InputAction.CallbackContext context)
    {
        isBuilding = context.ReadValueAsButton();
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        isReloading = context.ReadValueAsButton();
    }

    #endregion

    #region Build Action Map Events

    private void OnConfirm(InputAction.CallbackContext context)
    {
        didConfirm = context.ReadValueAsButton();
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        didCancel = context.ReadValueAsButton();
    }

    #endregion
}
