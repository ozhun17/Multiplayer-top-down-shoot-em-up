using System;
using Enemy_Logic;
using Interfaces;
using Unity.Netcode;
using UnityEngine;

namespace Player.Bullet_Logic
{
    public class Bullet : NetworkBehaviour, ISpawnedObject
    {
        private Rigidbody2D _rigidbody;

        public void Spawn()
        {
            OnNetworkSpawn();
        }

        private void Start()
        {
            OnNetworkSpawn();
        }

        public override void OnNetworkSpawn()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            base.OnNetworkSpawn();
            Shoot();
        }

        private void Shoot()
        {
            _rigidbody.velocity = transform.up * 5;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!IsServer) return;
            collision.transform.TryGetComponent<Enemy>(out Enemy enemy);
            if (enemy == null) return;
            enemy.gameObject.GetComponent<NetworkObject>().Despawn();
            Destroy(enemy.gameObject);
            this.GetComponent<NetworkObject>().Despawn();
            Destroy(this.gameObject);
        }


    

    }
}
