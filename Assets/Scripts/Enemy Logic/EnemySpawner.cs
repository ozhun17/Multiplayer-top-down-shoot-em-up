using System.Collections;
using Managers;
using Unity.Netcode;
using UnityEngine;

namespace Enemy_Logic
{
    public class EnemySpawner : NetworkBehaviour
    {
    
        void Update()
        {
            if (!IsServer) return;
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(Spawn());
            }

        }


        private IEnumerator Spawn()
        {
            while(true)
            {
                ObjectSpawner.Singleton.SpawnWithName("Enemy", transform);
                yield return new WaitForSeconds(3.0f);
            }
        
        }

    }
}
