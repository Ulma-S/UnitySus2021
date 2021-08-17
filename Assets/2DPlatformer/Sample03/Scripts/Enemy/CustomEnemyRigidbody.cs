using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// EnemyのRigidbodyを制御するクラス.
    /// </summary>
    public class CustomEnemyRigidbody : MonoBehaviour {
        [SerializeField] private Rigidbody2D m_rb;

        private void OnTriggerEnter2D(Collider2D col) {
            //範囲内にPlayerが入ったら物理運動を止める.
            if (col.gameObject.CompareTag("Player")) {
                m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            //範囲内からPlayerが出たら回転のみ止める.
            if (col.gameObject.CompareTag("Player")) {
                m_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}