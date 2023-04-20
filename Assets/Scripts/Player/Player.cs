using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{



    
    private void Start()
    {
        PlayerManager.Singleton.AddPlayer(this);
    }

}
