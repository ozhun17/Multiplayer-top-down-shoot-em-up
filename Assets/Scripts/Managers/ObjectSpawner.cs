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

        public GameObject SpawnWithName(string objectName, Transform objectTransform)
        {
            return SpawnWithNameRpc(objectName, objectTransform);
        }
        

        [ServerRpc]
        private GameObject SpawnWithNameRpc(string objectName, Transform objectTransform)
        {
            GameObject prefab = PrefabStore.Singleton.FindByName(objectName);
            GameObject sceneGameObject = Instantiate(prefab, objectTransform.position, objectTransform.rotation, null);
            sceneGameObject.GetComponent<NetworkObject>().Spawn(true);
            sceneGameObject.GetComponent<ISpawnedObject>().Spawn();
            return sceneGameObject;
        }


    }

}