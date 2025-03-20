using TMPro;  // Importing TextMeshPro for advanced text rendering
using UCR.ECCI.PI.frontend.Unity.Application;  // Importing application services
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using UnityEngine;  // Importing Unity engine core functionalities
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;  // Importing Zenject for dependency injection

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class WhiteboardController : MonoBehaviour
    {
        private IWhiteboardService _whiteboardService;  // Service interface for Whiteboard-related functionalities
        private TMP_Text _interactionTextWhiteboard;  // Text component for displaying interaction messages
        private TMP_InputField _inputField;
        [SerializeField] private float interactionDistance = 3f;  // Maximum distance for interaction
        private Transform _playerTransform;  // Reference to the player's transform for distance checking
        private Canvas canvasInteraction;  // Reference to the interaction canvas
        private bool isAvailable = true;  // Track the Whiteboard's state

        [Inject]
        public void Construct(IWhiteboardService whiteboardService)
        {
            _whiteboardService = whiteboardService;  // Assigning the injected service to the class field
        }

        void Awake()
        {
            canvasInteraction = transform.Find("CanvasInteractionWhiteboard").GetComponent<Canvas>();
            if (canvasInteraction == null)
            {
                Debug.LogError("CanvasInteraction not found.");
                return;
            }

            _interactionTextWhiteboard = canvasInteraction.transform.Find("_interactionTextWhiteboard").GetComponent<TMP_Text>();
            if (_interactionTextWhiteboard == null)
            {
                Debug.LogError("Text component not found.");
                return;
            }

            _inputField = canvasInteraction.transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
            if (_inputField == null)
            {
                Debug.LogError("InputField component not found.");
                return;
            }


            _interactionTextWhiteboard.gameObject.SetActive(true);  // Disable interaction text initially
            _interactionTextWhiteboard.text = "'E' Tomar marcador";
            _inputField.interactable = false;

        }

        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _playerTransform = player.transform;  // Assign the player's transform
            }
            else
            {
                Debug.LogError("Player with tag 'Player' not found.");
            }
        }


        void disablePlayerMovement()
        {
            PlayerInput playerInputActions = _playerTransform.GetComponent<PlayerInput>();
            playerInputActions.enabled = false;
        }

        void enablePlayerMovement()
        {
            PlayerInput playerInputActions = _playerTransform.GetComponent<PlayerInput>();
            playerInputActions.enabled = true;
        }

        void Update()
        {
            if (_playerTransform == null || _interactionTextWhiteboard == null) return;

            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            bool isCloseEnough = distance <= interactionDistance;

            _interactionTextWhiteboard.gameObject.SetActive(isCloseEnough);  // Activate interaction text if within range

            // Check for interaction key press if the interaction text is active
            if (isCloseEnough && Input.GetKeyDown(KeyCode.E))
            {
                HandleWhiteboardInteraction();  // Call the interaction method
                _interactionTextWhiteboard.text = "'Tab' Dejar marcador";
                disablePlayerMovement();
            }

            // Check if "Tab" key is pressed to deactivate InputField
            if (isCloseEnough && Input.GetKeyDown(KeyCode.Tab))
            {
                DeactivateInputField();  // Call method to handle deactivation
                _interactionTextWhiteboard.text = "'E' Tomar marcador";
                enablePlayerMovement();
            }
        }

        private void HandleWhiteboardInteraction()
        {
            if (_whiteboardService != null)
            {
                _whiteboardService.BlockWhiteboard();  // Change the Whiteboard state
                isAvailable = _whiteboardService.IsAvailable();   // Update local state tracking

                _inputField.interactable = true;
                _inputField.Select();

            }
        }

        private void DeactivateInputField()
        {
            // Deactivate the InputField
            _inputField.interactable = false;
            _inputField.DeactivateInputField();
            EventSystem.current.SetSelectedGameObject(null);

            // Change the state and update the interaction text
            isAvailable = true;
        }
    }
}