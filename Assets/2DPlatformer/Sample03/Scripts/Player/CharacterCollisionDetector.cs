using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// キャラクターの衝突判定を管理するクラス.
    /// </summary>
    public class CharacterCollisionDetector : MonoBehaviour {
        /// <summary>
        /// 判定するレイヤー.
        /// </summary>
        [SerializeField] private LayerMask m_layerMask;
        
        /// <summary>
        /// Rayの長さ.
        /// </summary>
        [SerializeField] private float m_rayLength = 1f;
        
        /// <summary>
        /// 接地しているか判定するメソッド.
        /// </summary>
        /// <returns></returns>
        public bool IsGround() {
            var ray = new Ray2D(transform.position, Vector2.down);
#if UNITY_EDITOR
            Debug.DrawRay(ray.origin, ray.direction * m_rayLength, Color.red);
#endif
            var hitInfo = Physics2D.Raycast(ray.origin, ray.direction, m_rayLength, m_layerMask);
            if (hitInfo.collider != null) { 
                return true; 
            }
            return false;
        }
    }
}