using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// PLayerの何もしないStateを制御するクラス.
    /// </summary>
    public class PlayerIdleState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private static readonly int Speed = Animator.StringToHash("Speed");

        protected override void Initialize() {
            //Stateの登録.
            stateMachine.RegisterState(EPlayerStateType.Idle, this);

            //最初はこのStateにする.
            stateMachine.ChangeState(EPlayerStateType.Idle);
        }

        public override void OnEnter() {
            //AnimatorのSpeed変数を0に設定する.
            m_animator.SetFloat(Speed, 0f);
        }

        public override void OnUpdate() {
            //ジャンプボタンが入力されたらJumpStateに遷移する.
            if (inputProvider.IsJumpPressed) {
                stateMachine.ChangeState(EPlayerStateType.Jump);
            }
            
            //移動が入力されたらMoveStateに遷移する.
            if (Mathf.Abs(inputProvider.HorizontalInput) > 0f) {
                stateMachine.ChangeState(EPlayerStateType.Run);
            }
            
            //攻撃ボタンが押されたらAttackStateに遷移する.
            if (inputProvider.IsAttackPressed) {
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