using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class ServerStartUp : MonoBehaviour
    {

        private const string InternalIpAddress = "0.0.0.0";
        private const ushort _port = 7777;
        void Start()
        {

          
                StartServer();
           
           
     
        }

        private static void StartServer()
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData
                (InternalIpAddress, _port);   
            NetworkManager.Singleton.StartServer();
        }


    }
}
