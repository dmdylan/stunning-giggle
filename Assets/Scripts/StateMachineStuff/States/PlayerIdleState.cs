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
            
        }

        public override void CheckSwitchStates()
        {
            if (CurrentSuperState != Ctx.CurrentState)
            {
                if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting && !Ctx.Input.IsShooting && !Ctx.Input.IsAiming)
                    SwitchState(Factory.Running());
                else if (Ctx.Input.MovementVector != Vector2.zero)// && !Ctx.Input.IsSprinting)
                    SwitchState(Factory.Walking());
            }
            else
            {
                if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                    SwitchState(Factory.Walking());
                else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting)
                    SwitchState(Factory.Running());
                else if (Ctx.Input.IsReloading || (Ctx.Input.IsShooting && Ctx.GemController.CurrentEnergy == 0))
                    SwitchState(Factory.Reloading());
                else if (Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                    SwitchState(Factory.AimShooting());
                else if (Ctx.Input.IsAiming)
                    SwitchState(Factory.Aiming());
                else if (!CurrentSuperState.Equals(typeof(PlayerReloadingState)) && Ctx.Input.IsShooting)
                    SwitchState(Factory.Shooting());
                else if (Ctx.Input.IsBuilding)
                    SwitchState(Factory.Building());
            }
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

        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }
    }
}