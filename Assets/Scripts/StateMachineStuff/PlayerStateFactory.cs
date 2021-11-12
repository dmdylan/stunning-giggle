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
    }
}