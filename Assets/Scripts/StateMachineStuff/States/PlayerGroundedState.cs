using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerGroundedState : PlayerBaseState
    {
        public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            IsRootState = true;
            InitializeSubState();
        }


        public override void CheckSwitchStates()
        {
            if (Ctx.Input.Jumped && Ctx.JumpTimeoutDelta <= 0.0f)
                SwitchState(Factory.Jumped());
        }

        public override void EnterState()
        {
            Ctx.FallTimeoutDelta = Ctx.FallTimeout;
            
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDGrounded, Ctx.Grounded);
            }
        }

        public override void ExitState()
        {
            // update animator if using character
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDGrounded, Ctx.Grounded);
            }

            
        }

        //TODO: Add more substates if they need to be implemented after a jump
        public override void InitializeSubState()
        {
            if (Ctx.IsBuilding)
                SetSubState(Factory.Building());
            else if (Ctx.Input.IsShooting)
                SetSubState(Factory.Shooting());
            else if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SetSubState(Factory.Walking());
            else
                SetSubState(Factory.Running());
        }

        public override void UpdateState()
        {
            CheckSwitchStates();

            if (Ctx.VerticalVelocity < 0.0f)
            {
                Ctx.VerticalVelocity = -2f;
            }

            if (Ctx.JumpTimeoutDelta >= 0.0f)
            {
                Ctx.JumpTimeoutDelta -= Time.deltaTime;
            }
        }


    }
}