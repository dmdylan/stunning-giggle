using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerWalkingState : PlayerBaseState
    {
        public PlayerWalkingState(PlayerStateMachine currentContext, PlayerStateFactory factory)
            :base(currentContext, factory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SwitchState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting)
                SwitchState(Factory.Running());
        }

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeSubState()
        {
            if (!Ctx.Grounded)
                return;

            if (Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                SetSubState(Factory.AimShooting());
            else if (Ctx.Input.IsAiming)
                SetSubState(Factory.Aiming());
            else if (Ctx.Input.IsShooting)
                SetSubState(Factory.Shooting());
            else if (Ctx.Input.IsReloading)
                SetSubState(Factory.Reloading());
            else if (Ctx.Input.IsBuilding)
                SetSubState(Factory.Building());
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }

    }
}