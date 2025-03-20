using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Application.Services;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.HID.HID;
using Unity.Netcode;
using System.Net;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
using Unity.Netcode.Transports.UTP;
using TMPro;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class ClientNetworkManager : MonoBehaviour
    {
        [SerializeField]
        private string _ipAddress;


        [Inject]
        private IEventChannel _eventChannel;

        [SerializeField]
        private GameObject _connectButton; 

        [SerializeField]
        private TMP_Text _statusText; 

        private Coroutine _connectionCheckCoroutine;
        private bool _isConnected = false;
        private float _connectionTimeout = 3f;




        public async void TryConnect()
        {

       //     _connectButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
            _statusText.text = "Connecting...";

            StartClient();
 
        }


        public void StartClient()
        {
           
            if (NetworkManager.Singleton == null)
            {
                Debug.LogError("NetworkManager.Singleton is null.");
                return;
            }


            UnityTransport transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            if (transport == null)
            {
                
                transport = NetworkManager.Singleton.gameObject.AddComponent<UnityTransport>();
                Debug.Log("UnityTransport component was added dynamically.");
            }

 
            transport.SetConnectionData(_ipAddress, 7777);
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

            // Start Client
            NetworkManager.Singleton.StartClient();

        }

        private void OnClientConnected(ulong clientId)
        {
          
            Debug.Log($"Client connected with ID: {clientId}");
            _eventChannel.Publish(new ConnectionSuccessEvent());
        }

        private void OnClientDisconnected(ulong clientId)
        {
            Debug.Log($"Client disconnected with ID: {clientId}");
            _statusText.text = "Connected!";
            _connectButton.SetActive(false);
            _eventChannel.Publish(new ConnectionFailedEvent("Try Again"));
        }

        private void DisplayError(string errorMessage)
        {
          //  _statusText.text = errorMessage;
            Debug.LogError(errorMessage);
        }

      
    }
}
