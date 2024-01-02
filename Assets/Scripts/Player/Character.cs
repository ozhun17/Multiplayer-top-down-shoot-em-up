using Player.PlayerInstances;
using Unity.Netcode;
using UnityEngine;

namespace Player
{
    public class Character: NetworkBehaviour
    {
        private PlayerInstance _playerInstance;
        private void Start()
        {
            PlayerInstanceBuilder builder = new();
            _playerInstance = IsLocalPlayer
                ? builder.BuildPlayerInstance(PlayerInstances.PlayerInstances.Local, gameObject)
                : builder.BuildPlayerInstance(PlayerInstances.PlayerInstances.Online, gameObject);
            
        }
    }
}