using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Networking;
public class PlayerManager: NetworkBehaviour
{
    
    private List<Player> Players;
    public static PlayerManager Singleton;

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


    public void AddPlayer(Player player)
    {
        if (IsServer) { AddPlayer(player, true); }
        else { AddPlayerServerRPC(player, true); }
    }

    private void AddPlayer(Player player, bool tru)
    {
        Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        if (IsServer) { RemovePlayer(player, true); }
        else { RemovePlayerServerRPC(player, true); }

    }

    private void RemovePlayer(Player player, bool tru)
    {
        Players.Remove(player);
    }


    [ServerRpc]
    private void RemovePlayerServerRPC(Player player, bool tru)
    {
        Players.Remove(player);
    }
    [ServerRpc]
    private void AddPlayerServerRPC(Player player, bool tru)
    {
        Players.Add(player);
    }


}
