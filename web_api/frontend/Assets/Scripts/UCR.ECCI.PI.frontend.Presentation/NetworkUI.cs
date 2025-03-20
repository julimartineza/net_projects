using Unity.Netcode;
using UnityEngine;

namespace UCR.ECCI.PI.frontend.Unity.Presentation
{
    public class NetworkUI : MonoBehaviour
    {
  

        public void StartClient()
        {
            NetworkManager.Singleton.StartClient();
        }

        public void StartServer()
        {
            NetworkManager.Singleton.StartServer();
        }


    }
}
