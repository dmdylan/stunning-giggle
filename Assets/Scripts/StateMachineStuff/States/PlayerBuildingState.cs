using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineStuff
{
    public class PlayerBuildingState : PlayerBaseState 
    {
        private bool exitInput = false;
        private bool isBuilding = false;
        
        //TODO: Used later to subtract resources of built object?
        //private bool didBuild = false;

        public PlayerBuildingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory)
        {
            InitializeSubState();
        }

        public override void CheckSwitchStates()
        {
            if (exitInput == false)
                return;

            if(exitInput)
                SwitchState(CurrentSubState);
        }

        public override void EnterState()
        {
            Ctx.IsBuilding = true;

            Ctx.Input.ToggleCombatActionMap();
            Ctx.Input.ToggleBuildActionMap();

            //Show build menu of item meant to be placed
        }

        public override void ExitState()
        {
            Ctx.IsBuilding = false;

            Ctx.Input.ToggleBuildActionMap();
            Ctx.Input.ToggleCombatActionMap();
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.MovementVector == Vector2.zero)
                SetSubState(Factory.Idle());
            else if (Ctx.Input.MovementVector != Vector2.zero && !Ctx.Input.IsSprinting)
                SetSubState(Factory.Walking());
        }

        public override void UpdateState()
        {
            if (!isBuilding && Ctx.Input.DidCancel)
                exitInput = true;

            CheckSwitchStates();
        }
    }
}