using UnityEngine;
using TMPro; 
using Zenject;
using UCR.ECCI.PI.frontend.Unity.Domain;
using System.Collections;


namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class ConnectionUIHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _connectButton;

        [SerializeField]
        private TMP_Text _statusText;

        [Inject]
        private IEventChannel _eventChannel;

        [Inject]
        public void Construct(IEventChannel eventChannel)
        {
            _eventChannel = eventChannel;
        }

        private void OnEnable()
        {
            _eventChannel.Subscribe<ConnectionSuccessEvent>(OnConnectionSuccess);
            _eventChannel.Subscribe<ConnectionFailedEvent>(OnConnectionFailed);
        }

        private void OnDisable()
        {
            _eventChannel.Unsubscribe<ConnectionSuccessEvent>(OnConnectionSuccess);
            _eventChannel.Unsubscribe<ConnectionFailedEvent>(OnConnectionFailed);
        }

        private void OnConnectionSuccess(ConnectionSuccessEvent e)
        {
            _statusText.text = "Connected!";
            _connectButton.SetActive(false); // Ocultar botón
        }

        private void OnConnectionFailed(ConnectionFailedEvent e)
        {
            Debug.Log($"Updating text error message");
            StartCoroutine(ShowErrorMessage(e.ErrorMessage, 3f));
            _connectButton.SetActive(true); // Mostrar botón de nuevo
        }

        private IEnumerator ShowErrorMessage(string errorMessage, float duration)
        {
            Debug.Log($"Setting error message: {errorMessage}");
            _statusText.text = errorMessage; // Actualiza el texto
            yield return new WaitForSeconds(duration);

        }
    }
}
