using UnityEngine;

namespace Player.PlayerInstances.Local.LocalPlayerScripts
{
    public class PlayerMovement: MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private PlayerInstance _playerInstance;
        private InputSystem.InputSystem _inputSystem;
        private float _moveSpeed = 5f;

        private void Awake()
        {
            this._rigidbody2D = GetComponent<Rigidbody2D>();
            this._playerInstance = GetComponent<PlayerInstance>();
            _inputSystem = GetComponent<InputSystem.InputSystem>();
        }

        private void Update()
        {
            _rigidbody2D.velocity = _inputSystem.GetAxis() * _moveSpeed;
        }
    }
}

