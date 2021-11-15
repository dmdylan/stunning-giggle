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
    }
}