using System.Collections.Generic;
using Player.PlayerInstances;
using Unity.Netcode;

namespace Managers
{
    public class PlayerManager: NetworkBehaviour
    {
    
        private List<PlayerInstance> _players;
        public static PlayerManager Singleton;

        private void Awake()
        {
            if (Singleton != null && Singleton != this)
            {
                Destroy(this);
            }
            else
            {
                Singleton = this;
            }
        }


        public void AddPlayer(PlayerInstance player)
        {
            if (IsServer) { AddPlayer(player, true); }
        }

        private void AddPlayer(PlayerInstance player, bool tru)
        {
            _players.Add(player);
        }

        public void RemovePlayer(PlayerInstance player)
        {
            if (IsServer) { RemovePlayer(player, true); }

        }

        private void RemovePlayer(PlayerInstance player, bool tru)
        {
            _players.Remove(player);
        }


    


    }
}
