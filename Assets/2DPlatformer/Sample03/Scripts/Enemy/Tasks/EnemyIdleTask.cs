using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class EnemyIdleTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.Idle;

        private float m_elapsedTime = 0f;

        public EnemyIdleTask(GameObject parent) : base(parent) {
        }
        
        public override void OnEnter() {
            m_elapsedTime = 0f;
        }

        public override bool OnUpdate() {
            //一定時間後にIdleTaskを終了.
            m_elapsedTime += Time.deltaTime;
            if (m_elapsedTime > enemyStatus.IdleTime) {
                return true;
            }
            return false;
        }

        public override void OnExit() {
        }
    }
}