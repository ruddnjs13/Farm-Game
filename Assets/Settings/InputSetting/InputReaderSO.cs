using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Settings.InputSetting
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader", order = 0)]
    public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
    {
        private Controls _controls;
        
        public Vector2 InputDirection { get; private set; }

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.Enable();
            }
            _controls.Player.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
        
        

        public void OnMove(InputAction.CallbackContext context)
        {
            InputDirection = context.ReadValue<Vector2>().normalized;
        }
        
        
    }
}