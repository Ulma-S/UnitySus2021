using UnityEngine;

namespace UnitySus2021.Sample03 {
    public abstract class EnemyTaskBase : ITask<EEnemyTaskType> {
        public virtual EEnemyTaskType TaskType { get; protected set; } = EEnemyTaskType.Idle;
        protected GameObject self { get; } = null;
        protected GameObject player { get; } = null;

        protected EnemyTaskBase(GameObject self) {
            this.self = self;
            player = GameObject.FindWithTag("Player");
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