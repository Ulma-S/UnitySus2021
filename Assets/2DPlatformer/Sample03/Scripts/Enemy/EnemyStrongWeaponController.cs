using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class EnemyStrongWeaponController : MonoBehaviour {
        private int m_attackPower;

        private void Start() {
            m_attackPower = Locator.Resolve<EnemyStatus>().StrongAttackPower;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.TryGetComponent(out IDamageable damageable) && !col.CompareTag("Enemy")) {
                damageable.ApplyDamage(m_attackPower);
            }
        }
    }
}