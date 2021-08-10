using UnityEngine;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class EnemyHpModel : MonoBehaviour, IDamageable {
        private float m_maxHp;
        private float m_currentHp;
        public float HpPercent => m_currentHp / m_maxHp;

        private void Start() {
            m_maxHp = Locator.Resolve<EnemyStatus>().MaxHp;
            m_currentHp = m_maxHp;
        }

        private void Update() {
            if (m_currentHp <= 0f) {
                GameManager.GameStatus = EGameStatus.GameClear;
            }
        }

        public void ApplyDamage(int value) {
            m_currentHp -= value;
        }
    }
}