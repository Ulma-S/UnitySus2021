using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class EnemyRangeController : MonoBehaviour {
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
