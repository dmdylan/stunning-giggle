using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerAimShootingState : PlayerBaseState
    {
        public PlayerAimShootingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Input.IsSprinting)
                SwitchState(Factory.Running());
            else if (!Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                SwitchState(Factory.Shooting());
            else if (Ctx.Input.IsAiming && !Ctx.Input.IsShooting)
                SwitchState(Factory.Aiming());
            else if(!Ctx.Input.IsAiming && !Ctx.Input.IsShooting)
                SwitchState(CurrentSubState);
            else if (Ctx.Input.IsReloading)
                SwitchState(Factory.Reloading());
            else if (Ctx.Input.IsBuilding)
                SwitchState(Factory.Building());
        }

        public override void EnterState()
        {
            Ctx.Speed = Ctx.AdsSpeed;
            Ctx.AimCam.Priority += 10;
        }

        public override void ExitState()
        {
            Ctx.AimCam.Priority -= 10;
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SetSubState(Factory.Walking());
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }
    }
}