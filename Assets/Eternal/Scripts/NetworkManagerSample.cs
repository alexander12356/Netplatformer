using UnityEngine;
using UnityEngine.Networking;

namespace Eternal
{
    public class NetworkManagerSample : NetworkManager
    {
        public UnetGameRoom GameRoom;

        [SerializeField]
        private CharacterState _characterPrefab;

        public Transform newPlayerPositionTransform;

        void Awake()
        {
            if (GameRoom == null)
            {
                Debug.LogError("Game Room property is not set on NetworkManager");
                return;
            }
            
            GameRoom.PlayerJoined += OnPlayerJoined;
            GameRoom.PlayerLeft += OnPlayerLeft;
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);

            GameRoom.ClientDisconnected(conn);
        }

        private void OnPlayerJoined(UnetMsfPlayer player)
        {
            SpawnPlayer(player.Connection);
        }

        private void OnPlayerLeft(UnetMsfPlayer player)
        {

        }

        public CharacterState SpawnPlayer(NetworkConnection connection)
        {
            var player = Instantiate(_characterPrefab);

            player.transform.position = newPlayerPositionTransform.position;

            NetworkServer.AddPlayerForConnection(connection, player.gameObject, 0);

            return player;
        }
    }
}