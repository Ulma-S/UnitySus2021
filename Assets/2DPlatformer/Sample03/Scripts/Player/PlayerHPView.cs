using UnityEngine;
using UnityEngine.UI;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// PlayerのHPを表示するUIを制御するクラス.
    /// </summary>
    public class PlayerHPView : MonoBehaviour {
        [SerializeField] private Image m_gage;
        private PlayerHpModel m_hpModel;

        private void Start() {
            m_hpModel = FindObjectOfType<PlayerHpModel>();
        }

        private void Update() {
            //ゲージの値にHPの割合を設定する.
            m_gage.fillAmount = m_hpModel.HpPercent;
        }
    }
}