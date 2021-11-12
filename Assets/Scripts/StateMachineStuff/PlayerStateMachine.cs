using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachineStuff
{
    public class PlayerStateMachine : MonoBehaviour
    {
        PlayerBaseState currentState;
        PlayerStateFactory states;

        //Getters and setters
        public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }

        private void Awake()
        {
            //Setup state
            states = new PlayerStateFactory(this);
            currentState = states.Grounded();
            currentState.EnterState();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateStates();
        }
    }
}