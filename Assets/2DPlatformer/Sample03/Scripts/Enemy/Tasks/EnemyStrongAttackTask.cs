using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Enemyの強攻撃Taskを管理するクラス.
    /// </summary>
    public class EnemyStrongAttackTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.StrongAttack;

        private readonly Animator m_animator;
        private static readonly int IsStrongAttack = Animator.StringToHash("IsStrongAttack");

        public EnemyStrongAttackTask(GameObject parent) : base(parent) {
            m_animator = self.GetComponent<Animator>();
        }
        
        public override void OnEnter() {
            //強攻撃のアニメーション再生.
            m_animator.SetBool(IsStrongAttack, true);
            
            //方向の設定 (攻撃中は方向を変更しない).
            ApplyLocalScale();
        }

        public override bool OnUpdate() {
            //StrongAttackのアニメーション終了時にTaskを終了する.
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("StrongAttack")) {
                if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) {
                    return true;
                }
            }
            return false;
        }

        public override void OnExit() {
            //強攻撃のアニメーション終了.
            m_animator.SetBool(IsStrongAttack, false);
        }
    }
}