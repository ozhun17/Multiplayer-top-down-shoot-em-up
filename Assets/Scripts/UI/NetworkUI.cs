using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NetworkUI : MonoBehaviour
    {
        public Button host;
        public Button client;

        // Update is called once per frame
        void Awake()
        {
            host.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartHost();
            });
            client.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartClient();
            });
        }
    }
}
