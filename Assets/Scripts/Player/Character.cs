using System;
using Player.Bullet_Logic;
using Player.PlayerInstances;
using Player.PlayerInstances.Local;
using Player.PlayerInstances.Online;
using Unity.Netcode;
using UnityEngine;

namespace Player
{
    public class Character: NetworkBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        private PlayerInstance _playerInstance;
        private Transform _gunTransform;
        private void Start()
        {
            _playerInstance = IsLocalPlayer
                ? this.gameObject.AddComponent<LocalPlayerInstance>()
                : this.gameObject.AddComponent<OnlinePlayerInstance>();
            _gunTransform = transform.Find("Center").Find("Gun");


        }
    }
}