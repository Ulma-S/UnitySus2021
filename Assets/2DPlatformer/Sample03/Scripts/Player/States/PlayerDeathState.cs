using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの死亡Stateを制御するクラス.
    /// </summary>
    public class PlayerDeathState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private static readonly int IsDeath = Animator.StringToHash("IsDeath");

        protected override void Initialize() {
            //Stateの登録.
            stateMachine.RegisterState(EPlayerStateType.Death, this);
        }

        public override void OnEnter() {
            //死亡アニメーションの再生.
            m_animator.SetBool(IsDeath, true);
        }

        public override void OnUpdate() {
        }

        public override void OnExit() {
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
        }
    }
}