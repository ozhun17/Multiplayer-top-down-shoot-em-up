using System.Collections.Generic;
using Unity.Netcode;

namespace InputSystem
{
    using UnityEngine;
    using Unity.Netcode;



    public class TempInput : InputSystem
    {
        private Vector2 _axisInput = Vector2.zero;
        

        protected override void CalculateInputs()
        {
            
            this._axisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetMouseButtonDown(0))
            {
                NarrateLeftClick();
            }
        }
        
        public override Vector2 GetAxis() { return _axisInput; }
    }
}