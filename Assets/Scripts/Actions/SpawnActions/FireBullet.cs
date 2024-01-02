using Interfaces;
using Managers;
using UnityEngine;

namespace Actions.SpawnActions
{
    public class FireBullet : MonoBehaviour, IAction
    {
        private Transform _gunTransform;

        private void Start()
        {
            _gunTransform = transform.Find("Center").Find("Gun");

        }

        public void Perform()
        {
            Fire();
        }

        
        
        public void Fire()
        {
            ObjectSpawner.Singleton.SpawnWithName("Bullet", _gunTransform);
        }
        
    }
}
