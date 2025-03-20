using System.Collections.Generic;
using TMPro;
using UCR.ECCI.PI.frontend.Unity.Application;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class TvController : MonoBehaviour
    {
        private ITvService _tvService;
        private TMP_Text _interactionText;
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private List<VideoClip> videoClips;
        private Transform _playerTransform;
        private Canvas canvasInteraction;
        private VideoPlayer videoPlayer;
        private Renderer videoRenderer;
        private int currentVideoIndex = 0;

        [Inject]
        public void Construct(ITvService tvService)
        {
            _tvService = tvService;
        }

        void Awake()
        {
            InitializeCanvasComponents();
        }

        void Start()
        {
            InitializePlayerReference();
            InitializeVideoComponents();
        }

        void Update()
        {
            HandleInteractionDistance();
        }

        private void InitializeCanvasComponents()
        {
            // Buscar el Canvas y sus componentes
            canvasInteraction = transform.Find("CanvasInteractionTv")?.GetComponent<Canvas>();
            if (canvasInteraction == null)
            {
                Debug.LogError($"Canvas 'CanvasInteractionTv' no encontrado en {gameObject.name}");
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

        private void InitializeVideoComponents()
        {
            Transform videoPlayerTransform = transform.Find("Video-player");
            if (videoPlayerTransform == null)
            {
                Debug.LogError($"No se encontró 'Video-player' en {gameObject.name}");
                return;
            }

            videoPlayer = videoPlayerTransform.GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                Debug.LogError($"No se encontró componente VideoPlayer en Video-player");
                return;
            }

            videoRenderer = videoPlayerTransform.GetComponent<Renderer>();
            if (videoRenderer == null)
            {
                Debug.LogError($"No se encontró componente Renderer en Video-player");
                return;
            }

            // Inicializar estado del video
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoRenderer.enabled = false;
            videoPlayer.Pause();
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
                HandleTvInteraction();
            }
            if (isCloseEnough && Input.GetKeyDown(KeyCode.Tab))
            {
                currentVideoIndex = (currentVideoIndex + 1) % videoClips.Count;
                videoPlayer.clip = videoClips[currentVideoIndex];
                UpdateVideoPlayer();
            }
        }

        private void HandleTvInteraction()
        {
            if (_tvService == null)
            {
                Debug.LogError("TvService no está inicializado");
                return;
            }

            _tvService.ChangeStatus();
            UpdateInteractionText();
            UpdateVideoPlayer();
        }

        private void UpdateVideoPlayer()
        {
            if (videoPlayer == null || videoRenderer == null)
            {
                return;
            }

            if (_tvService.IsOn())
            {
                videoPlayer.Stop();
                videoPlayer.Play();
                videoPlayer.SetDirectAudioMute(0, false);
                videoRenderer.enabled = true;
            }
            else
            {
                videoPlayer.SetDirectAudioMute(0, true);
                videoRenderer.enabled = false;
            }
        }

        private void UpdateInteractionText()
        {
            if (_interactionText == null || _tvService == null)
            {
                return;
            }

            _interactionText.text = _tvService.IsOn() ? "E para Apagar" : " E para Encender";
        }

        // Método público para verificar el estado del TV (útil para debugging)
        public bool IsInitialized()
        {
            return _tvService != null &&
                   _interactionText != null &&
                   canvasInteraction != null &&
                   videoPlayer != null &&
                   videoRenderer != null;
        }
    }
}