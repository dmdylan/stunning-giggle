using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerJumpingState : PlayerBaseState
    {
        public PlayerJumpingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            :base(currentContext, playerStateFactory)
        {
            IsRootState = true;
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.FallTimeoutDelta >= 0.0f)
                Ctx.FallTimeoutDelta -= Time.deltaTime;
            else
                SwitchState(Factory.Falling());
        }

        public override void EnterState()
        {
            // the square root of H * -2 * G = how much velocity needed to reach desired height
            Ctx.VerticalVelocity = Mathf.Sqrt(Ctx.JumpHeight * -2f * Ctx.Gravity);

            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDJump, true);
            }

            Ctx.JumpTimeoutDelta = Ctx.JumpTimeout;
        }

        public override void ExitState()
        {
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDJump, false);
            }
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SetSubState(Factory.Walking());
            else
                SetSubState(Factory.Running());

            CurrentSubState.IsSubRootState = true;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }

    }
}