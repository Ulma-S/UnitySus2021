using UnityEngine;

namespace UnitySus2021.Sample03 {
    [CreateAssetMenu(menuName = "UnitySus2021/EnemyStatus")]
    public class EnemyStatus : ScriptableObject {
        public float MoveSpeed;
        public int MaxHp;
        public int WeakAttackPower;
        public int StrongAttackPower;
        public float StrongAttackInterval;
        public float WeakAttackInterval;
        public float IdleTime;
        public float MaxRunTime;
    }
}