using System;
using UnityEngine;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// PlayerのHPを管理するクラス.
    /// </summary>
    public class PlayerHpModel : MonoBehaviour, IDamageable {
        [SerializeField] private PlayerStateMachine m_stateMachine;
        private float m_maxHp;
        private float m_currentHp;
        
        /// <summary>
        /// 総HPに対する現在のHPの割合.
        /// </summary>
        public float HpPercent => m_currentHp / m_maxHp;
        
        /// <summary>
        /// ダメージを受けた時に呼ばれるコールバック.
        /// </summary>
        public event Action OnDamagedHandler;
        
        private void Start() {
            m_maxHp = Locator.Resolve<PlayerStatus>().MaxHp;
            m_currentHp = m_maxHp;
        }

        private void Update() {
            //HPが0になったら
            if (m_currentHp <= 0f) {
                m_stateMachine.ChangeState(EPlayerStateType.Death);
                GameManager.GameState = EGameState.GameOver;
            }
        }

        public void ApplyDamage(int attackValue) {
            m_currentHp -= attackValue;
            OnDamagedHandler?.Invoke();
        }

        private void Reset() {
            m_stateMachine = GetComponent<PlayerStateMachine>();
        }
    }
}