using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Enemyの移動Taskを管理するクラス.
    /// </summary>
    public class EnemyRunTask : EnemyTaskBase {
        public override EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.Run;

        private readonly Animator m_animator;
        private readonly Rigidbody2D m_rb;
        private static readonly int Speed = Animator.StringToHash("Speed");

        /// <summary>
        /// Task開始からの経過時間.
        /// </summary>
        private float m_elapsedTime = 0f;

        public EnemyRunTask(GameObject parent) : base(parent) {
            m_animator = self.GetComponent<Animator>();
            m_rb = self.GetComponent<Rigidbody2D>();
        }
        
        public override void OnEnter() {
            //経過時間のリセット.
            m_elapsedTime = 0f;
        }

        public override bool OnUpdate() {
            //速度を反映.
            var velocity = m_rb.velocity;
            velocity.x = GetPlayerDir() * enemyStatus.MoveSpeed;
            m_rb.velocity = velocity;
            
            //方向を反映.
            ApplyLocalScale();
            
            m_animator.SetFloat(Speed, Mathf.Abs(m_rb.velocity.x));
            
            //経過時間を計算.
            m_elapsedTime += Time.deltaTime;
            if (m_elapsedTime > enemyStatus.MaxRunTime) {
                return true;
            }
            return false;
        }

        public override void OnExit() {
            m_animator.SetFloat(Speed, 0f);
        }
    }
}