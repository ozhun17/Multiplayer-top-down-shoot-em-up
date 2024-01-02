using Interfaces;
using Unity.Netcode;
using UnityEngine;

namespace Managers
{
    public class ObjectSpawner : NetworkBehaviour
    {
        
        public static ObjectSpawner Singleton;

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

        public void SpawnWithName(string objectName, Transform objectTransform)
        {
            SpawnWithNameServerRpc(objectName, objectTransform.position, objectTransform.rotation);
        }
        [ServerRpc(RequireOwnership = false)]
        private void SpawnWithNameServerRpc(string objectName, Vector3 position, Quaternion rotation)
        {
            GameObject prefab = PrefabStore.Singleton.FindByName(objectName);
            GameObject sceneGameObject = Instantiate(prefab, position, rotation, null);
            sceneGameObject.GetComponent<NetworkObject>().Spawn(true);
            sceneGameObject.GetComponent<ISpawnedObject>().Spawn();
        }
        
        


    }

}