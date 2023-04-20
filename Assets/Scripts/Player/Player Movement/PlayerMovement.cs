using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private Vector2 MoveInput;
    private float MoveSpeed = 5;
    private Rigidbody2D _rb;
    private bool instabullet =false;
    private Gun gun;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        if (!IsLocalPlayer) { return; }
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        instabullet |= Input.GetKeyDown(KeyCode.K);
    }

    private void FixedUpdate()
    {
        if (instabullet && IsOwner) { gun.Fire(); instabullet = false; }
        if(IsServer && IsLocalPlayer)
        {
            Move(MoveInput);
            gun.LookAtMouse();
        }
        if(IsClient && IsLocalPlayer)
        {
            gun.LookAtMouse();
            MoveServerRPC(MoveInput);
        }
    }



    private void Move(Vector2 moveinp)
    {
        _rb.velocity = moveinp * MoveSpeed;
    }


    [ServerRpc]
    private void MoveServerRPC(Vector2 moveinp)
    {
        _rb.velocity = moveinp * MoveSpeed;
    }


}
