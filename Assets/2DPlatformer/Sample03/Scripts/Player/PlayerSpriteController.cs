using System.Collections;
using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class PlayerSpriteController : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_sr;
        [SerializeField] private PlayerHpModel m_hpModel;

        private void Start() {
            m_hpModel.OnDamagedHandler += OnDamaged;
        }

        private void OnDamaged() {
            StartCoroutine(BlinkCoroutine());
        }

        /// <summary>
        /// ダメージを受けると点滅させる.
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