using UnityEngine;
using UnityEngine.UI;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// EnemyのHPを表すUIを制御するクラス.
    /// </summary>
    public class EnemyHpView : MonoBehaviour {
        [SerializeField] private EnemyHpModel m_hpModel;
        [SerializeField] private Image m_gage;
        
        private void Update() {
            //ゲージの値に現在のHPの割合を設定する.
            m_gage.fillAmount = m_hpModel.HpPercent;
        }
    }
}