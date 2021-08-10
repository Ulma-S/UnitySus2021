using UnityEngine;

namespace UnitySus2021.Sample02 {
    [CreateAssetMenu(menuName = "UnitySus2021/PlayerStatus")]
    public class PlayerStatus : ScriptableObject {
        public float MoveSpeed;
        public float JumpForce;
        public float LocalGravityScale;
        public float MaxHp;
        public int WeakAttackPower;
        public int StrongAttackPower;
    }
}