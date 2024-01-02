using Player.PlayerInstances.Local.LocalPlayerScripts;
using UnityEngine;

namespace Player.PlayerInstances
{
    public class PlayerInstance : MonoBehaviour
    {
        internal InputSystem.InputSystem PlayerInput;
        internal PlayerMovement PlayerMovement;
        private void Start()
        {
            Initialize();
        }

        internal virtual void Initialize(){ }

        
    }

}
