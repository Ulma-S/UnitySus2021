using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class ExplosionController : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_sprite;
        [SerializeField] private Animator m_animator;

        private void Update() {
            //アニメーション終了時にSpriteを非表示にする.
            if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) {
                m_sprite.enabled = false;
            }
        }

        private void Reset() {
            m_sprite = GetComponent<SpriteRenderer>();
            m_animator = GetComponent<Animator>();
        }
    }
}