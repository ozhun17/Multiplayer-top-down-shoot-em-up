using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class PrefabStore : MonoBehaviour
    {
    
    
        [SerializeField]private NetworkPrefabsList networkPrefabs;
        public readonly Dictionary<string, GameObject> PrefabList = new();
        public static PrefabStore Singleton;

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
            foreach (var networkPrefab in networkPrefabs.PrefabList)
            {
                Debug.Log(networkPrefab.Prefab.GameObject().name);
                PrefabList.Add( networkPrefab.Prefab.GameObject().name ,(networkPrefab.Prefab.GameObject()));
            }
            Debug.Log(PrefabList);
        }

        public GameObject FindByName(string objectName)
        {
            GameObject go;
            bool op = PrefabList.TryGetValue(objectName, out go);
            Debug.Log("fetched object = " + go);
            return go;
        }
    }
}
