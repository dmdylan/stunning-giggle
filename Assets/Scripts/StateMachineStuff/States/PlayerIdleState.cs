using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SwitchState(Factory.Walking());
            else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting)
                SwitchState(Factory.Running());
        }

        public override void EnterState()
        {
            Ctx.TargetSpeed = 0f;
            Ctx.Speed = Ctx.TargetSpeed;
        }

        public override void ExitState()
        {

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