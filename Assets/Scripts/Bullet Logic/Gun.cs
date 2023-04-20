using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Gun : NetworkBehaviour
{
    [SerializeField] private GameObject Center;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject Bullet;


    public void Fire()
    {
        if(IsLocalPlayer && IsOwner) { FireServerRPC(true); }

    }


    [ServerRpc]
    private void FireServerRPC(bool isServer)
    {
        GameObject bulletGO = Instantiate(Bullet, _gun.transform.position, _gun.transform.rotation, null);
        bulletGO.GetComponent<NetworkObject>().Spawn(false);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.OnNetworkSpawn();
    }




    public void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(Center.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var angleaxis = Quaternion.AngleAxis(angle, Vector3.forward);
        if(IsServer && IsLocalPlayer) { setRotation(angleaxis); }
        if(IsClient && IsLocalPlayer) { setRotationServerRPC(angleaxis); }
    }

    private void setRotation(Quaternion angleaxis)
    {
        Center.transform.rotation = angleaxis;
    }

    [ServerRpc]
    private void setRotationServerRPC(Quaternion angleaxis)
    {
        Center.transform.rotation = angleaxis;
    }
}
