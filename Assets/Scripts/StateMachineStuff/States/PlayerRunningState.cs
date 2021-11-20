using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerRunningState : PlayerBaseState
    {
        public PlayerRunningState(PlayerStateMachine currentContext, PlayerStateFactory factory)
            :base(currentContext, factory)
        {

        }

        public override void CheckSwitchStates()
        {
            if (CurrentSuperState != Ctx.CurrentState)
            {
                if (Ctx.Input.MovementVector == Vector2.zero)
                    SwitchState(Factory.Idle());
                else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                    SwitchState(Factory.Walking());
            }
            else
            {
                if (Ctx.Input.MovementVector == Vector2.zero)
                    SwitchState(Factory.Idle());
                else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                    SwitchState(Factory.Walking());
                else if (Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                    SwitchState(Factory.AimShooting());
                else if (Ctx.Input.IsAiming)
                    SwitchState(Factory.Aiming());
                else if (Ctx.Input.IsShooting)
                    SwitchState(Factory.Shooting());
                else if (Ctx.Input.IsReloading)
                    SwitchState(Factory.Reloading());
                else if (Ctx.Input.IsBuilding)
                    SwitchState(Factory.Building());
            }
        }

        //TODO: Use CanRunAgain bool to check if player is able to run again after switching states
        public override void EnterState()
        {
            Ctx.TargetSpeed = Ctx.SprintSpeed;
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

            float currentHorizontalSpeed = new Vector3(Ctx.Controller.velocity.x, 0.0f, Ctx.Controller.velocity.z).magnitude;

            float speedOffset = 0.1f;

            // accelerate or decelerate to target speed
            if (currentHorizontalSpeed < Ctx.TargetSpeed - speedOffset || currentHorizontalSpeed > Ctx.TargetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                Ctx.Speed = Mathf.Lerp(currentHorizontalSpeed, Ctx.TargetSpeed * Ctx.InputMagnitude, Time.deltaTime * Ctx.SpeedChangeRate);

                // round speed to 3 decimal places
                Ctx.Speed = Mathf.Round(Ctx.Speed * 1000f) / 1000f;
            }
        }

    }
}