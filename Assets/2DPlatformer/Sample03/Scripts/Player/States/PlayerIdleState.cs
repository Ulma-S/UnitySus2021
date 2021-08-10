using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerIdleState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private IInputProvider m_inputProvider;
        private static readonly int Speed = Animator.StringToHash("Speed");

        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Idle, this);

            m_inputProvider = Locator.Resolve<IInputProvider>();
            
            stateMachine.ChangeState(EPlayerStateType.Idle);
        }

        public override void OnEnter() {
            m_animator.SetFloat(Speed, 0f);
        }

        public override void OnUpdate() {
            //ジャンプボタンが入力されたらJumpStateに遷移する.
            if (m_inputProvider.IsJumpPressed) {
                stateMachine.ChangeState(EPlayerStateType.Jump);
            }
            
            //移動が入力されたらMoveStateに遷移する.
            if (Mathf.Abs(m_inputProvider.HorizontalInput) > 0f) {
                stateMachine.ChangeState(EPlayerStateType.Run);
            }
            
            //攻撃ボタンが押されたらAttackStateに遷移する.
            if (m_inputProvider.IsAttackPressed) {
                stateMachine.ChangeState(EPlayerStateType.Attack);
            }
        }

        public override void OnExit() {
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
        }
    }
}