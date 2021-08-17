using UnityEngine;

namespace UnitySus2021.Sample02 {
    /// <summary>
    /// Playerのステータス.
    /// </summary>
    [CreateAssetMenu(menuName = "UnitySus2021/PlayerStatus")]
    public class PlayerStatus : ScriptableObject {
        /// <summary>
        /// 移動速度.
        /// </summary>
        public float MoveSpeed;
        
        /// <summary>
        /// ジャンプ力.
        /// </summary>
        public float JumpForce;
        
        /// <summary>
        /// 重力.
        /// </summary>
        public float LocalGravityScale;
        
        /// <summary>
        /// 最大HP.
        /// </summary>
        public float MaxHp;
        
        /// <summary>
        /// 弱攻撃の攻撃力 (今回は弱攻撃を実装していないので使いません.)
        /// </summary>
        public int WeakAttackPower;
        
        /// <summary>
        /// 今日攻撃の攻撃力.
        /// </summary>
        public int StrongAttackPower;
    }
}