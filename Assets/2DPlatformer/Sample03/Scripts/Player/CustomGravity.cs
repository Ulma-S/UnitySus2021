using UnityEngine;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// 独自の重力を制御するクラス.
    /// </summary>
    public class CustomGravity : MonoBehaviour {
        [SerializeField] private Rigidbody2D m_rb;
        private float m_localGravityScale;

        private void Start() {
            m_localGravityScale = Locator.Resolve<PlayerStatus>().LocalGravityScale;
        }

        private void Update() {
            //重力の更新.
            ApplyLocalGravity();
        }

        /// <summary>
        /// 重力を反映する.
        /// </summary>
        private void ApplyLocalGravity() {
            var velocity = m_rb.velocity;
            velocity.y -= m_localGravityScale * Time.deltaTime;
            m_rb.velocity = velocity;
        }

        private void Reset() {
            m_rb = GetComponent<Rigidbody2D>();
        }
    }
}