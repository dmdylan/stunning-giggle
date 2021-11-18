using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerAimingState : PlayerBaseState
    {
        public PlayerAimingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (!Ctx.Input.IsAiming)
                Debug.Log("Need to swap out of aiming state");
        }

        public override void EnterState()
        {
            Ctx.AimCam.Priority += 10;
        }

        public override void ExitState()
        {
            Ctx.AimCam.Priority -= 10;
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
        }
    }
}