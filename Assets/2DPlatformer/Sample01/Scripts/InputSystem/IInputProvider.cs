namespace UnitySus2021.InputSystem {
    public interface IInputProvider {
        float HorizontalInput { get; }
        bool IsJumpPressed { get; }
    }
}