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
            throw new System.NotImplementedException();
        }

        public override void EnterState()
        {
            if (Ctx.HasAnimator)
            {
                Ctx.Animator.SetBool(Ctx.AnimIDJump, true);
            }
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeSubState()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState()
        {
            throw new System.NotImplementedException();
        }

    }
}