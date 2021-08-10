using UnityEngine;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class EnemyRunTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.Run;

        private readonly Animator m_animator;
        private readonly Rigidbody2D m_rb;
        private readonly EnemyStatus m_enemyStatus;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private float m_elapsedTime = 0f;

        public EnemyRunTask(GameObject parent) : base(parent) {
            m_animator = self.GetComponent<Animator>();
            m_rb = self.GetComponent<Rigidbody2D>();
            m_enemyStatus = Locator.Resolve<EnemyStatus>();
        }
        
        public override void OnEnter() {
            

            m_elapsedTime = 0f;
        }

        public override bool OnUpdate() {
            //速度を反映.
            var velocity = m_rb.velocity;
            velocity.x = GetPlayerDir() * m_enemyStatus.MoveSpeed;
            m_rb.velocity = velocity;
            
            //方向を反映.
            ApplyLocalScale();
            
            m_animator.SetFloat(Speed, Mathf.Abs(m_rb.velocity.x));
            
            //経過時間を計算.
            m_elapsedTime += Time.deltaTime;
            if (m_elapsedTime > m_enemyStatus.MaxRunTime) {
                return true;
            }
            return false;
        }

        public override void OnExit() {
            m_animator.SetFloat(Speed, 0f);
        }
    }
}