namespace StateMachineStuff
{
    public abstract class PlayerBaseState
    {
        private bool isRootState = false;
        private PlayerStateMachine ctx;
        private PlayerStateFactory factory;
        private PlayerBaseState currentSubState;
        private PlayerBaseState currentSuperState;

        protected bool IsRootState { set { isRootState = value; } }
        protected PlayerStateMachine Ctx { get { return ctx; } }
        protected PlayerStateFactory Factory { get { return factory; } }

        //For debugging
        public PlayerBaseState CurrentSubState => currentSubState;

        public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        {
            ctx = currentContext;
            factory = playerStateFactory;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract void CheckSwitchStates();
        public abstract void InitializeSubState();

        public void UpdateStates()
        {
            UpdateState();

            if (currentSubState != null)
                currentSubState.UpdateStates();
        }

        //Might not be needed
        public void ExitStates()
        {
            ExitState();

            if (currentSubState != null)
                currentSubState.ExitStates();
        }

        protected void SwitchState(PlayerBaseState newState)
        {
            ExitState();

            newState.EnterState();

            if (isRootState)
                //switches current state if it is declared a root state in it's constructor
                ctx.CurrentState = newState;
            else if (currentSuperState != null)
                //sets the current super states sub state to newState
                currentSuperState.SetSubState(newState);
        }

        protected void SetSuperState(PlayerBaseState newSuperState)
        {
            currentSuperState = newSuperState;
        }

        protected void SetSubState(PlayerBaseState newSubState)
        {
            currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }
    }
}