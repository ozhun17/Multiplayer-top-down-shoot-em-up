using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    
    

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(IsServer&&IsOwner){ Shoot(); }
        if (IsClient&&IsOwner) ShootServerRPC();
    }

    private void Shoot()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 5;
    }

    [ServerRpc]
    private void ShootServerRPC()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 5;
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
