using UnityEngine;

namespace UnitySus2021.Sample03 {
    [CreateAssetMenu(menuName = "UnitySus2021/EnemyStatus")]
    public class EnemyStatus : ScriptableObject {
        public float MoveSpeed;
        public int Hp;
        public int WeakAttackPower;
        public int StrongAttackPower;
        public float AttackInterval;
        public float MaxRunTime;
    }
}