using UnityEngine;
using UnityEngine.UI;

namespace UnitySus2021.Sample03 {
    public class EnemyHpView : MonoBehaviour {
        [SerializeField] private EnemyHpModel m_hpModel;
        [SerializeField] private Image m_gage;
        
        private void Update() {
            m_gage.fillAmount = m_hpModel.HpPercent;
        }
    }
}