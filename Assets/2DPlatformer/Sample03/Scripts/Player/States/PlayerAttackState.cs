using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの攻撃Stateを制御するクラス.
    /// </summary>
    public class PlayerAttackState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        protected override void Initialize() {
            //Stateの登録.
            stateMachine.RegisterState(EPlayerStateType.Attack, this);
        }

        public override void OnEnter() {
            //攻撃アニメーション再生.
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
            //攻撃アニメーション終了.
            m_animator.SetBool(IsAttack, false);
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
        }
    }
}