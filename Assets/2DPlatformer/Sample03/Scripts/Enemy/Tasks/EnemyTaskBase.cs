using UnityEngine;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// EnemyのTaskの基底クラス.
    /// </summary>
    public abstract class EnemyTaskBase : ITask<EEnemyTaskType> {
        public virtual EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.Idle;
        
        /// <summary>
        /// Enemy自身のGameObjectの参照.
        /// </summary>
        protected GameObject self { get; } = null;
        
        /// <summary>
        /// PlayerのGameObjectの参照.
        /// </summary>
        protected GameObject player { get; } = null;
        
        /// <summary>
        /// Enemyのステータス.
        /// </summary>
        protected EnemyStatus enemyStatus { get; } = null;

        protected EnemyTaskBase(GameObject self) {
            this.self = self;
            player = GameObject.FindWithTag("Player");
            enemyStatus = Locator.Resolve<EnemyStatus>();
        }

        public abstract void OnEnter();

        public abstract bool OnUpdate();

        public abstract void OnExit();
        
        /// <summary>
        /// Enemyから見てPlayerが左右どちらにあるかを取得するメソッド.
        /// </summary>
        /// <returns></returns>
        protected int GetPlayerDir() {
            var dir = player.transform.position.x - self.transform.position.x;

            if (dir > 0f) {
                return 1;
            }
            return -1;
        }
        
        /// <summary>
        /// 方向を反映するメソッド.
        /// </summary>
        protected void ApplyLocalScale() {
            var localScale = self.transform.localScale;
            if (GetPlayerDir() > 0) {
                localScale.x = -Mathf.Abs(localScale.x);
            }else if (GetPlayerDir() < 0) {
                localScale.x = Mathf.Abs(localScale.x);
            }
            self.transform.localScale = localScale;
        }
    }
}