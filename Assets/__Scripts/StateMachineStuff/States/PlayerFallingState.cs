using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerFallingState : PlayerBaseState
    {
        public PlayerFallingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            :base(currentContext, playerStateFactory)
        {
            IsRootState = true;
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Grounded)
                SwitchState(Factory.Grounded());
        }

        public override void EnterState()
        {
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDFreeFall, true);
            }
        }

        public override void ExitState()
        {
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDFreeFall, false);
            }
        }

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
        }
    }
}