using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class PlayerAttackState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Attack, this);
        }

        public override void OnEnter() {
            m_animator.SetBool(IsAttack, true);
        }

        public override void OnUpdate() {
            //StrongAttackのアニメーション終了時にStateを遷移する.
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("StrongAttack")) {
                if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) {
                    stateMachine.ChangeState(EPlayerStateType.Idle);
                }
            }
        }

        public override void OnExit() {
            m_animator.SetBool(IsAttack, false);
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
        }
    }
}