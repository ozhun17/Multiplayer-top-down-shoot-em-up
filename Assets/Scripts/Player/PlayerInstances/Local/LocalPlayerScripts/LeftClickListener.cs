using System;
using UnityEngine;
using InputSystem;
using Interfaces;

namespace Player.PlayerInstances.Local.LocalPlayerScripts
{
    public class LeftClickListener: MonoBehaviour, ILeftClickListener
    {
        private InputSystem.InputSystem _inputSystem;
        private IAction _leftClickAction;

        private void Start()
        {
            _inputSystem = GetComponent<InputSystem.InputSystem>();
            _inputSystem.ListenLeftClick(this);
        }

        public void InsertAction(IAction action)
        {
            this._leftClickAction = action;
        }

        public void LeftClickPressed()
        {
            _leftClickAction.Perform();
        }
    }
}