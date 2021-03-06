using UnityEngine;

namespace UnitySus2021.InputSystem {
    /// <summary>
    /// キーボード入力を提供するクラス.
    /// </summary>
    public class KeyboardInputProvider : MonoBehaviour, IInputProvider {
        public float HorizontalInput { get; private set; }
        public bool IsJumpPressed { get; private set; }
        public bool IsAttackPressed { get; private set; }

        private void Update() {
            //入力値の更新.
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            IsJumpPressed = Input.GetKeyDown(KeyCode.Space);
            IsAttackPressed = Input.GetKeyDown(KeyCode.J);
        }
    }
}