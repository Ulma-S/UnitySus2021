using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Enemyの攻撃可能範囲内にPlayerがいるか判定するクラス.
    /// </summary>
    public class EnemyRangeController : MonoBehaviour {
        /// <summary>
        /// Playerが範囲内にいるか?
        /// </summary>
        public bool IsInRange { get; private set; } = false;
        
        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                IsInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                IsInRange = false;
            }
        }
    }
}
