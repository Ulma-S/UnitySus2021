using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class EnemyStrongAttackTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.StrongAttack;

        private readonly Animator m_animator;
        private static readonly int IsStrongAttack = Animator.StringToHash("IsStrongAttack");

        public EnemyStrongAttackTask(GameObject parent) : base(parent) {
            m_animator = self.GetComponent<Animator>();
        }
        
        public override void OnEnter() {
            m_animator.SetBool(IsStrongAttack, true);
            ApplyLocalScale();
        }

        public override bool OnUpdate() {
            if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) {
                return true;
            }
            return false;
        }

        public override void OnExit() {
            m_animator.SetBool(IsStrongAttack, false);
        }
    }
}