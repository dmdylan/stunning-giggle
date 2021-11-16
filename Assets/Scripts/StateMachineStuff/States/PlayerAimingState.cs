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

        }

        public override void CheckSwitchStates()
        {
            //throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }
    }
}