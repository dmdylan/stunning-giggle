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
            //InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (CurrentSuperState != Ctx.CurrentState)
            {
                if (Ctx.Input.MovementVector == Vector2.zero)
                    SwitchState(Factory.Idle());
                else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting)
                    SwitchState(Factory.Running());
            }
            else
            {
                if (Ctx.Input.MovementVector == Vector2.zero)
                    SwitchState(Factory.Idle());
                else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting)
                    SwitchState(Factory.Running());
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

        public override void EnterState()
        {
            Ctx.TargetSpeed = Ctx.WalkSpeed;
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
            //InitializeSubState();

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