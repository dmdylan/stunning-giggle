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
            if (Ctx.Input.MovementVector == Vector2.zero)
                SwitchState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SwitchState(Factory.Walking());
        }

        public override void EnterState()
        {
            throw new System.NotImplementedException();
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
            CheckSwitchStates();
        }

    }
}