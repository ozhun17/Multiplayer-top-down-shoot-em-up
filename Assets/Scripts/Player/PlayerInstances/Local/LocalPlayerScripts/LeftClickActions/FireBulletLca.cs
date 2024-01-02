using Interfaces;
using Managers;
using Player.Bullet_Logic;
using Unity.Netcode;
using UnityEngine;

namespace Player.PlayerInstances.Local.LocalPlayerScripts.LeftClickActions
{
    public class FireBulletLca : MonoBehaviour, IAction
    {
        private Transform _gunTransform;

        private void Start()
        {
            Initiate();
        }

        private void Initiate()
        {
            
            _gunTransform = transform.Find("Center").Find("Gun");
        }

        

        public void Perform()
        {
            Debug.Log("entered Perform");
            Fire();
        }

        
        
        public void Fire()
        {
            NetworkObject bulletGo = ObjectSpawner.Singleton.SpawnWithName("Bullet", _gunTransform)
                .GetComponent<NetworkObject>();
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            bullet.OnNetworkSpawn();
        }
        
    }
}
