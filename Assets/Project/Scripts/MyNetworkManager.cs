using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        Debug.Log($"Connected as Server: {conn.address}");
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log($"Client connected. Players:{numPlayers}");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log($"Client connected. Players:{numPlayers}");
    }
}