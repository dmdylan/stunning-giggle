using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

namespace StateMachineStuff
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerStateMachine : MonoBehaviour
    {
        PlayerBaseState currentState;
        PlayerStateFactory states;
        PlayerInput input;
		Animator animator;
		CharacterController controller;
		GameObject mainCamera;

		[SerializeField] private TextMeshProUGUI stateDebugText;

		#region Private Variables

		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		[SerializeField] private float walkSpeed = 2.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		[SerializeField] private float sprintSpeed = 5.335f;
		[Tooltip("Speed of character when aiming down the sights")]
		[SerializeField] private float adsSpeed = 1.5f;
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
		[Tooltip("The virtual camera that will be used normally")]
		[SerializeField] private CinemachineVirtualCamera mainFollowCam;
		[Tooltip("The virtual camera that will be used for aiming down sights")]
		[SerializeField] private CinemachineVirtualCamera aimCam;
		[Tooltip("How far in degrees can you move the camera up")]
		[SerializeField] private float topClamp = 70.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		[SerializeField] private float bottomClamp = -30.0f;
		[Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
		[SerializeField] private float cameraAngleOverride = 0.0f;
		[Tooltip("For locking the camera position on all axis")]
		[SerializeField] private bool lockCameraPosition = false;

		// cinemachine - all are only used in the the camerarotation method, may not need own state
		private float cinemachineTargetYaw;
		private float cinemachineTargetPitch;
		[SerializeField] private float lookXSensitivity = 1f;
		[SerializeField] private float lookYSensitivity = 1f;

		// player
		private float speed;
		private float animationBlend;
		private float targetSpeed;
		private float inputMagnitude = 1.0f;
		private float targetRotation = 0.0f;
		private float rotationVelocity;
		private float verticalVelocity;
		private float terminalVelocity = 53.0f;

		// timeout deltatime
		private float jumpTimeoutDelta;
		private float fallTimeoutDelta;

		//All Getters
		// animation IDs
		private int animIDSpeed;
		private int animIDGrounded;
		private int animIDJump;
		private int animIDFreeFall;
		private int animIDMotionSpeed;

		private const float threshold = 0.01f;

		private bool hasAnimator;

		#endregion

		#region Getters and Setters

		public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }
        public PlayerInput Input => input;
		public Animator Animator => animator;
		public CharacterController Controller => controller;
		public GameObject MainCamera => mainCamera;
		public float WalkSpeed => walkSpeed;
		public float SprintSpeed => sprintSpeed;
		public float AdsSpeed => adsSpeed;
		public float RotationSmoothTime => rotationSmoothTime;
		public float SpeedChangeRate => speedChangeRate;
		public float JumpHeight => jumpHeight;
		public float Gravity => gravity;
		public float JumpTimeout => jumpTimeout;
		public float FallTimeout => fallTimeout;
		public bool Grounded { get { return grounded; } set { grounded = value; } }
		public float GroundedOffset => groundedOffset;
		public float GroundedRadius => groundedRadius;
		public LayerMask GroundLayers => groundLayers;
		public GameObject CinemachineCameraTarget => cinemachineCameraTarget;
		public CinemachineVirtualCamera MainFollowCam => mainFollowCam;
		public CinemachineVirtualCamera AimCam => aimCam;
		public float Speed { get { return speed; } set { speed = value; } }

		public float AnimationBlend { get { return animationBlend; } set { animationBlend = value; } }
		public float TargetSpeed { get { return targetSpeed; } set { targetSpeed = value; } }
		public float InputMagnitude { get { return inputMagnitude; } set { inputMagnitude = value; } }
		public float TargetRotation { get { return targetRotation; } set { targetRotation = value; } }
		public float RotationVelocity { get { return rotationVelocity; } set { rotationVelocity = value; } }
		public float VerticalVelocity { get { return verticalVelocity; } set { verticalVelocity = value; } }
		public float TerminalVelocity { get { return terminalVelocity; } set { terminalVelocity = value; } }
		public float JumpTimeoutDelta { get { return jumpTimeoutDelta; } set { jumpTimeoutDelta = value; } }
		public float FallTimeoutDelta { get { return fallTimeoutDelta; } set { fallTimeoutDelta = value; } }
		public int AnimIDSpeed => animIDSpeed;
		public int AnimIDGrounded => animIDGrounded;
		public int AnimIDJump => animIDJump;
		public int AnimIDFreeFall => animIDFreeFall;
		public int AnimIDMotionSpeed => animIDMotionSpeed;
		public bool HasAnimator => hasAnimator;

        #endregion

        private void Awake()
        {
			// get a reference to our main camera
			if (mainCamera == null)
			{
				mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}

			hasAnimator = TryGetComponent(out animator);
			controller = GetComponent<CharacterController>();
			input = GetComponent<PlayerInput>();

			AssignAnimationIDs();

			//Setup state
			//states = GetComponent<PlayerStateFactory>();
			states = new PlayerStateFactory(this);
            currentState = states.Grounded();
            currentState.EnterState();
        }

        // Start is called before the first frame update
        void Start()
        {
			jumpTimeoutDelta = JumpTimeout;
			fallTimeoutDelta = FallTimeout;
		}

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateStates();

			//TODO: Move to all root states?
			// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
			if (verticalVelocity < terminalVelocity)
			{
				verticalVelocity += gravity * Time.deltaTime;
			}

			GroundCheck();
			MovePlayer();

			if (currentState != null && currentState.CurrentSubState == null)
				stateDebugText.text = "Current State: " + currentState.GetType().Name;
			else if (currentState.CurrentSubState != null && currentState.CurrentSubState.CurrentSubState == null)
				stateDebugText.text = "Current State: " + currentState.GetType().Name + "\n" +
									"Current Substate: " + currentState.CurrentSubState.GetType().Name;
			else
				stateDebugText.text = "Current State: " + currentState.GetType().Name + "\n" +
				"Current Substate: " + currentState.CurrentSubState.GetType().Name + "\n" +
				"Curren substate substate: " + currentState.CurrentSubState.CurrentSubState.GetType().Name;
		}

        private void LateUpdate()
        {
			CameraRotation();
        }

		private void GroundCheck()
		{
			// set sphere position, with offset
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
			grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void MovePlayer()
        {
			animationBlend = Mathf.Lerp(animationBlend, targetSpeed, Time.deltaTime * speedChangeRate);

			// normalise input direction
			Vector3 inputDirection = new Vector3(input.MovementVector.x, 0.0f, input.MovementVector.y).normalized;

			targetRotation = mainCamera.transform.eulerAngles.y;
			transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);

			inputDirection = transform.TransformDirection(inputDirection);
			controller.Move(inputDirection * (speed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);

			// update animator if using character
			if (hasAnimator)
			{
				animator.SetFloat(animIDSpeed, animationBlend);
				animator.SetFloat(animIDMotionSpeed, inputMagnitude);
			}
		}

		private void AssignAnimationIDs()
		{
			animIDSpeed = Animator.StringToHash("Speed");
			animIDGrounded = Animator.StringToHash("Grounded");
			animIDJump = Animator.StringToHash("Jump");
			animIDFreeFall = Animator.StringToHash("FreeFall");
			animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
		}

		private void CameraRotation()
		{
			// if there is an input and camera position is not fixed
			if (input.LookVector.sqrMagnitude >= threshold && !lockCameraPosition)
			{
				cinemachineTargetYaw += input.LookVector.x * Time.deltaTime * lookXSensitivity;
				cinemachineTargetPitch += input.LookVector.y * Time.deltaTime * lookYSensitivity;
			}

			// clamp our rotations so our values are limited 360 degrees
			cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
			cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClamp, topClamp);

			// Cinemachine will follow this target
			CinemachineCameraTarget.transform.rotation = Quaternion.Euler(cinemachineTargetPitch + cameraAngleOverride, cinemachineTargetYaw, 0.0f);
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}
	}
}