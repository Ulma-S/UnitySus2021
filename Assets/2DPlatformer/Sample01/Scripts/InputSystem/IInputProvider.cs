namespace UnitySus2021.InputSystem {
    /// <summary>
    /// 入力を提供するインターフェース.
    /// </summary>
    public interface IInputProvider {
        /// <summary>
        /// 水平方向の入力値.
        /// </summary>
        float HorizontalInput { get; }
        
        /// <summary>
        /// ジャンプボタンが押されているか?
        /// </summary>
        bool IsJumpPressed { get; }
        
        /// <summary>
        /// 攻撃ボタンが押されているか?
        /// </summary>
        bool IsAttackPressed { get; }
    }
}