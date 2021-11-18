using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerShootingState : PlayerBaseState
    {
        public PlayerShootingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (!IsSubRootState)
                return;

            if (Ctx.Input.IsAiming && Ctx.Input.IsShooting)
                SwitchState(Factory.AimShooting());
            else if (Ctx.Input.IsAiming)
                SwitchState(Factory.Aiming());
            else if (!Ctx.Input.IsShooting)
                SwitchState(CurrentSubState);
            else if (Ctx.Input.IsReloading)
                SwitchState(Factory.Reloading());
            else if (Ctx.Input.IsBuilding)
                SwitchState(Factory.Building());
        }

        public override void EnterState()
        {
            Debug.Log("Entered shooting state");
        }

        public override void ExitState()
        {


            Debug.Log("Exited shooting state");

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

            Debug.Log("Updating shoot state");
        }
    }
}