using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class PlayerDeathState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private static readonly int IsDeath = Animator.StringToHash("IsDeath");

        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Death, this);
        }

        public override void OnEnter() {
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