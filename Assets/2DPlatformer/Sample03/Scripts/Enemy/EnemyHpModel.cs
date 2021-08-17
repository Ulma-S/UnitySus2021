using UnityEngine;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// EnemyのHPを制御するクラス.
    /// </summary>
    public class EnemyHpModel : MonoBehaviour, IDamageable {
        [SerializeField] private ExplosionController m_explosion;
        private float m_maxHp;
        private float m_currentHp;
        
        /// <summary>
        /// 最大HPに対する現在のHPの割合.
        /// </summary>
        public float HpPercent => m_currentHp / m_maxHp;

        private void Start() {
            m_maxHp = Locator.Resolve<EnemyStatus>().MaxHp;
            m_currentHp = m_maxHp;
        }

        private void Update() {
            //HPが0になったらEnemyを消して爆発アニメーションを再生する.
            if (m_currentHp <= 0f) {
                Instantiate(m_explosion, transform.parent.position, Quaternion.identity);
                GameManager.GameState = EGameState.GameClear;
                transform.parent.gameObject.SetActive(false);
            }
        }

        public void ApplyDamage(int attackValue) {
            m_currentHp -= attackValue;
        }
    }
}