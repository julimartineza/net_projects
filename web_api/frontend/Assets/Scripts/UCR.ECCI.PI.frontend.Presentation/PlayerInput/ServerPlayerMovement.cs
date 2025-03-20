using Unity.Netcode;
using UnityEngine;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    [RequireComponent(typeof(CharacterController))]
    public class ServerPlayerMovement : NetworkBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private float moveSpeed = 2.0f;
        [SerializeField] private float sprintSpeed = 5.335f;
        [SerializeField] private float rotationSmoothTime = 0.12f;
        [SerializeField] private float speedChangeRate = 10.0f;

        [Header("Jump and Gravity")]
        [SerializeField] private float gravity = -15.0f;
        [SerializeField] private float jumpHeight = 1.2f;
        [SerializeField] private float jumpTimeout = 0.5f;
        [SerializeField] private float fallTimeout = 0.15f;

        [Header("Grounded Check")]
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.28f;
        [SerializeField] private LayerMask groundLayers;

        [Header("Player Camera")]
        [SerializeField] private Camera playerCamera; // Cámara asociada al jugador

        private float _speed;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;

        private CharacterController _characterController;
        private UserInput _input;
        private Camera _cameraController;

        private bool _grounded;

        private void Start()
        {
            // Camera configuration
            cameraContr(_cameraController);

            _characterController = GetComponent<CharacterController>();
            _input = new UserInput();
            _input.Enable();

            _jumpTimeoutDelta = jumpTimeout;
            _fallTimeoutDelta = fallTimeout;
        }

        private void cameraContr(Camera _cameraController)
        {
            if (!IsLocalPlayer)
            {
                // Desactivar cámara de otros jugadores
                Camera localCamera = GetComponentInChildren<Camera>();
                if (localCamera != null)
                {
                    localCamera.enabled = false;
                }
                return;
            }

            // Configurar cámara para el jugador local
            _characterController = GetComponent<CharacterController>();
            _input = new UserInput();
            _input.Enable();

            _jumpTimeoutDelta = jumpTimeout;
            _fallTimeoutDelta = fallTimeout;

            // Buscar la cámara en los hijos del objeto jugador
            _cameraController = GetComponentInChildren<Camera>();

            if (_cameraController == null)
            {
                Debug.LogError("No se encontró una cámara en el jugador local.");
            }
        }

        private void Update()
        {
            // Solo procesar entradas para el jugador local
            if (!IsLocalPlayer) return;

            GroundedCheck();
            JumpAndGravity();

            Vector2 moveInput = _input.Player.Movement.ReadValue<Vector2>();
            bool isSprinting = _input.Player.Sprint.IsPressed();

            if (IsServer)
            {
                Move(moveInput, isSprinting);
            }
            else if (IsClient)
            {
                MoveServerRpc(moveInput, isSprinting);
            }
        }

        private void GroundedCheck()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
            _grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
        }

        private void JumpAndGravity()
        {
            if (_grounded)
            {
                _fallTimeoutDelta = fallTimeout;

                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                if (_input.Player.Jump.IsPressed() && _jumpTimeoutDelta <= 0.0f)
                {
                    _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }

                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else
            {
                _jumpTimeoutDelta = jumpTimeout;

                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }

                if (_verticalVelocity < -53.0f)
                {
                    _verticalVelocity += gravity * Time.deltaTime;
                }
            }
        }

        private void Move(Vector2 moveInput, bool isSprinting)
        {
            float targetSpeed = isSprinting ? sprintSpeed : moveSpeed;

            if (moveInput == Vector2.zero) targetSpeed = 0.0f;

            float currentHorizontalSpeed = new Vector3(_characterController.velocity.x, 0.0f, _characterController.velocity.z).magnitude;
            float speedOffset = 0.1f;
            float inputMagnitude = moveInput.magnitude;

            if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * speedChangeRate);
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }

            Vector3 inputDirection = new Vector3(moveInput.x, 0.0f, moveInput.y).normalized;

            if (moveInput != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

            Vector3 moveDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
        }

        [ServerRpc]
        private void MoveServerRpc(Vector2 moveInput, bool isSprinting)
        {
            Move(moveInput, isSprinting);
        }
    }
}