using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField] private GameObject Enemy;
    
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
            GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity, null);
            enemy.gameObject.GetComponent<NetworkObject>().Spawn();
            yield return new WaitForSeconds(3.0f);
        }
        
    }

}
