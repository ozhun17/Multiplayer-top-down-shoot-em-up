using System;
using Player.PlayerInstances.Local;
using Player.PlayerInstances.Online;
using UnityEngine;

namespace Player.PlayerInstances
{
    public class PlayerInstanceBuilder
    {
        
        public PlayerInstance BuildPlayerInstance(PlayerInstances instanceType ,GameObject gameObject)
        {
            switch (instanceType)
            {
                case PlayerInstances.Local:
                    return gameObject.AddComponent<LocalPlayerInstance>();
                case PlayerInstances.Online:
                    return gameObject.AddComponent<OnlinePlayerInstance>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(instanceType), instanceType, null);
            }
        }
    }
}