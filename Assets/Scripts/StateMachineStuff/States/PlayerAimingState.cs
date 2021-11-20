using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerAimingState : PlayerBaseState
    {
        public PlayerAimingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.IsSprinting && !Ctx.Input.IsAiming)
                SwitchState(Factory.Running());
            else if (Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                SwitchState(Factory.AimShooting());
            else if (!Ctx.Input.IsAiming)
                SwitchState(CurrentSubState);
            else if (Ctx.Input.IsShooting)
                SwitchState(Factory.Shooting());
            else if (Ctx.Input.IsReloading)
                SwitchState(Factory.Reloading());
            else if (Ctx.Input.IsBuilding)
                SwitchState(Factory.Building());
        }

        public override void EnterState()
        {
            Debug.Log("Entering aiming state");
            Ctx.AimCam.Priority += 10;

            if (CurrentSubState.GetType().Equals(typeof(PlayerWalkingState)))
                Ctx.TargetSpeed = Ctx.AdsSpeed;
        }

        public override void ExitState()
        {
            Ctx.AimCam.Priority -= 10;
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else
                SetSubState(Factory.Walking());
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }
    }
}