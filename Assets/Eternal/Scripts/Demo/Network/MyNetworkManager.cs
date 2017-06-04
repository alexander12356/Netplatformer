using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager 
{
    public Vector3[] Positions;

	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{
        Vector3 pos = Positions[playerControllerId];

        var player = Instantiate(playerPrefab, pos, Quaternion.identity) as GameObject;

		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}