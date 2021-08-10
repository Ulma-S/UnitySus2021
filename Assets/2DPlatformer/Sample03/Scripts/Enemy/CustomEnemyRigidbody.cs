using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class CustomEnemyRigidbody : MonoBehaviour {
        [SerializeField] private Rigidbody2D m_rb;

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            if (col.gameObject.CompareTag("Player")) {
                m_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}