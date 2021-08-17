using UnityEngine;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// 強攻撃の武器を管理するクラス.
    /// </summary>
    public class PlayerStrongWeaponController : MonoBehaviour {
        private int m_attackPower;
        
        private void Start() {
            m_attackPower = Locator.Resolve<PlayerStatus>().StrongAttackPower;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            //攻撃可能オブジェクトと衝突したらダメージを与える.
            if (col.gameObject.TryGetComponent(out IDamageable damageable) && !col.CompareTag("Player")) {
                damageable.ApplyDamage(m_attackPower);
            }
        }
    }
}