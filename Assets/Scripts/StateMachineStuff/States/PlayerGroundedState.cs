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
            if (Ctx.Input.Jumped && Ctx.JumpTimeout <= 0.0f)
                SwitchState(Factory.Jumped());
        }

        public override void EnterState()
        {
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDJump, false);
                Ctx.Animator.SetBool(Ctx.AnimIDFreeFall, false);
            }
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
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