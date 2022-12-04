using System;
using Mirror;
using UnityEngine;

namespace BornCore.MirrorDev
{
    public class MyNetworkManager : NetworkBehaviour
    {
        private NetworkConnectionToClient connection;
        public ConnectionStatus ConnectionStatus { get; private set; }

        private void OnGUI()
        {
            if (ConnectionStatus == ConnectionStatus.Connecting)
            {
                GUILayout.Label("Connecting...");
                return;
            }

            if (ConnectionStatus == ConnectionStatus.Connected)
            {
                if (GUILayout.Button("Disconnect"))
                {
                    connection.Disconnect();
                }

                return;
            }

            if (GUILayout.Button("Host"))
            {
                StartServer();
            }

            if (GUILayout.Button("Client"))
            {
                StartClient();
            }
        }


        public void StartServer()
        {
            Application.runInBackground = true;
            ConnectionStatus = ConnectionStatus.Connecting;
            NetworkServer.RegisterHandler<ConnectMessage>(OnServerConnect);
            NetworkServer.RegisterHandler<ReadyMessage>(OnClientReady);
            NetworkServer

            
            
            
            NetworkServer.Listen(4);
        }

        private void OnServerConnect(NetworkConnectionToClient connection, ConnectMessage arg2, int arg3)
        {
            Debug.Log($"Server: Connected to: {connection.address}");
            this.connection = connection;
        }
        
        void OnClientReady(NetworkConnectionToClient conn, ReadyMessage msg)
        {
            Debug.Log($"Server: Client ready, last log: {conn.lastMessageTime}");
            NetworkServer.SetClientReady(conn);
        }

        private void StartClient()
        {
            NetworkClient.RegisterHandler<ConnectMessage>(OnClientConnect);
            NetworkClient.Connect("localhost");
        }

        void OnClientConnect(ConnectMessage msg)
        {
            Debug.Log($"Client: Connected to server");
        }


        public struct ConnectMessage : NetworkMessage
        {
            public int ID;
            public Vector3 pos;
        }
    }

    public enum ConnectionStatus
    {
        Disconnected,
        Connecting,
        Connected
    }
}