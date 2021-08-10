using UnityEngine;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerStrongWeaponController : MonoBehaviour {
        private int m_attackPower;
        
        private void Start() {
            m_attackPower = Locator.Resolve<PlayerStatus>().StrongAttackPower;
        }

        /// <summary>
        /// 攻撃可能オブジェクトと衝突したらダメージを与える.
        /// </summary>
        /// <param name="col"></param>
        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.TryGetComponent(out IDamageable damageable) && !col.CompareTag("Player")) {
                damageable.ApplyDamage(m_attackPower);
            }
        }
    }
}