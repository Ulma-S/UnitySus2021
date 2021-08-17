using System.Collections;
using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの見た目を制御するクラス.
    /// </summary>
    public class PlayerViewController : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_sr;
        [SerializeField] private PlayerHpModel m_hpModel;
        private IEnumerator m_blinkCoroutine;

        private void Start() {
            //ダメージを受けた時に呼ばれるコールバックに設定する.
            m_hpModel.OnDamagedHandler += OnDamaged;

            m_blinkCoroutine = BlinkCoroutine();
        }

        private void OnDamaged() {
            StopCoroutine(m_blinkCoroutine);
            m_blinkCoroutine = null;
            m_blinkCoroutine = BlinkCoroutine();
            StartCoroutine(m_blinkCoroutine);
        }

        /// <summary>
        /// ダメージを受けるとPlayerを点滅させるコルーチン.
        /// </summary>
        /// <returns></returns>
        private IEnumerator BlinkCoroutine() {
            for (int i = 0; i < 3; i++) {
                var color = m_sr.color;
                color.a = 0.5f;
                m_sr.color = color;
                yield return new WaitForSeconds(0.1f);
                color.a = 1f;
                m_sr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Reset() {
            m_sr = GetComponent<SpriteRenderer>();
            m_hpModel = GetComponent<PlayerHpModel>();
        }
    }
}