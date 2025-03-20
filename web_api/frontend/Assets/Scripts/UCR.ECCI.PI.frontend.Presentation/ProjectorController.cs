using TMPro;
using UCR.ECCI.PI.frontend.Unity.Application;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class ProjectorController : MonoBehaviour
    {
        private IProjectorService _projectorService;
        private TMP_Text _interactionText;
        [SerializeField] private float interactionDistance = 5f;
        private Transform _playerTransform;
        private Canvas canvasInteraction;
        private GameObject quadObject;

        [Inject]
        public void Construct(IProjectorService projectorService)
        {
            _projectorService = projectorService;
        }

        void Awake()
        {
            InitializeCanvasComponents();
        }

        void Start()
        {
            InitializePlayerReference();
            InitializeProjectorScreen();
        }

        void Update()
        {
            HandleInteractionDistance();
        }

        private void InitializeCanvasComponents()
        {
            // Buscar el Canvas y sus componentes
            canvasInteraction = transform.Find("CanvasInteractionWhitProjector")?.GetComponent<Canvas>();
            if (canvasInteraction == null)
            {
                Debug.LogError($"Canvas 'CanvasInteractionWhitProjector' no encontrado en {gameObject.name}");
                return;
            }

            // Buscar el texto de interacción
            _interactionText = canvasInteraction.transform.Find("_interactionText")?.GetComponent<TMP_Text>();
            if (_interactionText == null)
            {
                Debug.LogError($"TextMeshPro '_interactionText' no encontrado en {canvasInteraction.name}");
                return;
            }

            _interactionText.gameObject.SetActive(false);
            UpdateInteractionText();
        }

        private void InitializePlayerReference()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _playerTransform = player.transform;
            }
            else
            {
                Debug.LogWarning("No se encontró objeto con tag 'Player' en la escena");
            }
        }

        private void InitializeProjectionComponents()
        {
            
        }

        private void InitializeProjectorScreen()
        {
            quadObject = GameObject.Find("ProjectorScreen"); // Reemplaza "QuadObjectName" con el nombre real del objeto Quad
            if (quadObject != null)
            {
                quadObject.SetActive(false); // Asegúrate de que el Quad esté desactivado por defecto
            }
            else
            {
                Debug.LogError("ProjectorScreen no encontrado en la escena");
            }
        }

        private void HandleInteractionDistance()
        {
            if (_playerTransform == null || _interactionText == null)
            {
                return;
            }

            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            bool isCloseEnough = distance <= interactionDistance;

            // Solo actualizar si el estado actual es diferente
            if (_interactionText.gameObject.activeSelf != isCloseEnough)
            {
                _interactionText.gameObject.SetActive(isCloseEnough);
            }

            if (isCloseEnough && Input.GetKeyDown(KeyCode.E))
            {
                HandleProjectorInteraction();
                ToggleProjectorScreen();
            }
        }

        private void HandleProjectorInteraction()
        {
            if (_projectorService == null)
            {
                Debug.LogError("ProjectorService no está inicializado");
                return;
            }

            _projectorService.ChangeStatus();
            UpdateInteractionText();
        }

        private void ToggleProjectorScreen()
        {
            if (quadObject != null)
            {
                quadObject.SetActive(!quadObject.activeSelf);
            }
        }

        private void UpdateProjectionPlayer()
        {
         
        }

        private void UpdateInteractionText()
        {
            if (_interactionText == null || _projectorService == null)
            {
                return;
            }

            _interactionText.text = _projectorService.IsOn() ? "Apagar 'E'" : "Encender 'E'";
        }

        // Método público para verificar el estado del TV (útil para debugging)
        public bool IsInitialized()
        {
            return _projectorService != null &&
                   _interactionText != null &&
                   canvasInteraction != null;
        }
    }
}