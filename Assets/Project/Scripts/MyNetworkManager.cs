using Mirror;
using UnityEngine;

namespace BornCore.MirrorDev
{
    public class MyNetworkManager : MonoBehaviour
    {
        [SerializeField] GameObject treePrefab;

        public void ClientConnect()
        {
            NetworkClient.RegisterPrefab(treePrefab);
            NetworkClient.RegisterHandler<ConnectMessage>(OnClientConnect);
            NetworkClient.Connect("localhost");
        }


        private void OnClientConnect(string obj)
        {
            throw new System.NotImplementedException();
        }


        void OnClientConnect(ConnectMessage msg)
        {
            Debug.Log("Connected to server: ");
        }

    }

    public struct ConnectMessage : NetworkMessage
    {
    }
}