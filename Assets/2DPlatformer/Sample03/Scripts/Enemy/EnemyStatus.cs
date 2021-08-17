using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Enemyのステータス.
    /// </summary>
    [CreateAssetMenu(menuName = "UnitySus2021/EnemyStatus")]
    public class EnemyStatus : ScriptableObject {
        /// <summary>
        /// 移動速度/
        /// </summary>
        public float MoveSpeed;
        
        /// <summary>
        /// 最大HP.
        /// </summary>
        public int MaxHp;
        
        /// <summary>
        /// 弱攻撃の攻撃力.
        /// </summary>
        public int WeakAttackPower;
        
        /// <summary>
        /// 強攻撃の攻撃力.
        /// </summary>
        public int StrongAttackPower;
        
        /// <summary>
        /// 何もしない状態の時間.
        /// </summary>
        public float IdleTime;
        
        /// <summary>
        /// 移動の最大時間.
        /// </summary>
        public float MaxRunTime;
    }
}