using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class EnemyWeakAttackTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.WeakAttack;

        private readonly Animator m_animator;
        private static readonly int IsWeakAttack = Animator.StringToHash("IsWeakAttack");

        public EnemyWeakAttackTask(GameObject parent) : base(parent) {
            m_animator = self.GetComponent<Animator>();
        }
        
        public override void OnEnter() {
            m_animator.SetBool(IsWeakAttack, true);
            ApplyLocalScale();
        }

        public override bool OnUpdate() {
            //StrongAttackのアニメーション終了時にTaskを終了する.
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("WeakAttack")) {
                if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) {
                    return true;
                }
            }

            return false;
        }

        public override void OnExit() {
            m_animator.SetBool(IsWeakAttack, false);
        }
    }
}