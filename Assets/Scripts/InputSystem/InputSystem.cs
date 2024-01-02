using System;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public interface ILeftClickListener
    {
        public void LeftClickPressed();
    }
    public class InputSystem: MonoBehaviour
    {
        
        public virtual Vector2 GetAxis() { return Vector2.zero; }
        internal List<ILeftClickListener> LeftClickListeners = new List<ILeftClickListener>();

        public void ListenLeftClick(ILeftClickListener listener)
        {
            LeftClickListeners.Add(listener);
        }

        internal void NarrateLeftClick()
        {
            foreach (var leftClickListener in LeftClickListeners)
            {
                leftClickListener.LeftClickPressed();
            }
        }

        private void Update()
        {
            CalculateInputs();
        }

        protected virtual void CalculateInputs(){}
    }
}