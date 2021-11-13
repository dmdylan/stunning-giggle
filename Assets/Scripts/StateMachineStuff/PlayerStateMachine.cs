using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachineStuff
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerStateMachine : MonoBehaviour
    {
        PlayerBaseState currentState;
        PlayerStateFactory states;
        PlayerInput input;

		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		[SerializeField] private float moveSpeed = 2.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		[SerializeField] private float sprintSpeed = 5.335f;
		[Tooltip("How fast the character turns to face movement direction")]
		[Range(0.0f, 0.3f)]
		[SerializeField] private float rotationSmoothTime = 0.12f;
		[Tooltip("Acceleration and deceleration")]
		[SerializeField] private float speedChangeRate = 10.0f;

		[Space(10)]
		[Tooltip("The height the player can jump")]
		[SerializeField] private float jumpHeight = 1.2f;
		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		[SerializeField] private float gravity = -15.0f;

		[Space(10)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		[SerializeField] private float jumpTimeout = 0.50f;
		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		[SerializeField] private float fallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		[SerializeField] private bool grounded = true;
		[Tooltip("Useful for rough ground")]
		[SerializeField] private float groundedOffset = -0.14f;
		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		[SerializeField] private float groundedRadius = 0.28f;
		[Tooltip("What layers the character uses as ground")]
		[SerializeField] private LayerMask groundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		[SerializeField] private GameObject cinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		[SerializeField] private float topClamp = 70.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		[SerializeField] private float bottomClamp = -30.0f;
		[Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
		[SerializeField] private float cameraAngleOverride = 0.0f;
		[Tooltip("For locking the camera position on all axis")]
		[SerializeField] private bool lockCameraPosition = false;


		//Getters and setters
		public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }
        public PlayerInput Input => input;

        private void Awake()
        {
            //Setup state
            states = GetComponent<PlayerStateFactory>();
            //states = new PlayerStateFactory(this);
            currentState = states.Grounded();
            currentState.EnterState();

            input = GetComponent<PlayerInput>();
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