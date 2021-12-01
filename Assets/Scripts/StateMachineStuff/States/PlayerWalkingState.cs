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
                else if (Ctx.Input.MovementVector != Vector2.zero && Ctx.Input.IsSprinting && !Ctx.Input.IsShooting && !Ctx.Input.IsAiming)
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

        //TODO: Speed gets overridden depending on what state is called first
        //walking -> aiming = aiming walk speed; aiming -> idle -> walking = normal walk speed;
        //You don't re-enter walking state when changing to aiming/aimshooting state
        public override void EnterState()
        {
            if (CurrentSuperState.GetType().Equals(typeof(PlayerAimingState)) || CurrentSuperState.GetType().Equals(typeof(PlayerAimShootingState)))
            {
                Ctx.TargetSpeed = Ctx.AdsSpeed;
            }
            else
            {
                Ctx.TargetSpeed = Ctx.WalkSpeed;
            }

            Debug.Log("Entered walking state");
        }

        public override void ExitState()
        {
            if (CurrentSuperState.GetType().Equals(typeof(PlayerAimingState)) || CurrentSuperState.GetType().Equals(typeof(PlayerAimShootingState)))
            {
                Ctx.TargetSpeed = Ctx.AdsSpeed;
            }
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