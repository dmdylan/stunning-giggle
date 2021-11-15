using System;

namespace StateMachineStuff
{
    public class PlayerStateFactory
    {
        PlayerStateMachine context;

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            context = currentContext;
        }

        //Methods to return new instances of other base states
        public PlayerBaseState Grounded()
        {
            return new PlayerGroundedState(context, this);
        }

        public PlayerBaseState Jumped()
        {
            return new PlayerJumpingState(context, this);
        }

        public PlayerBaseState Idle()
        {
            return new PlayerIdleState(context, this);
        }

        public PlayerBaseState Walking()
        {
            return new PlayerWalkingState(context, this);
        }

        public PlayerBaseState Running()
        {
            return new PlayerRunningState(context, this);
        }

        public PlayerBaseState Shooting()
        {
            return new PlayerShootingState(context, this);
        }

        public PlayerBaseState Aiming()
        {
            return new PlayerAimingState(context, this);
        }

        public PlayerBaseState AimShooting()
        {
            return new PlayerAimShootingState(context, this);
        }

        public PlayerBaseState Building()
        {
            return new PlayerBuildingState(context, this);
        }

        public PlayerBaseState Reloading()
        {
            return new PlayerReloadingState(context, this);
        }

        public PlayerBaseState Falling()
        {
            return new PlayerFallingState(context, this);
        }
    }
}