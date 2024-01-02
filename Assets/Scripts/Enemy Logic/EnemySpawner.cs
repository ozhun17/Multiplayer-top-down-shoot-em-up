using System.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Enemy_Logic
{
    public class EnemySpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject enemy;
    
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
                GameObject enemy = Instantiate(this.enemy, transform.position, Quaternion.identity, null);
                enemy.gameObject.GetComponent<NetworkObject>().Spawn();
                yield return new WaitForSeconds(3.0f);
            }
        
        }

    }
}
