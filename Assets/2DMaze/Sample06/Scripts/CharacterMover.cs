using System.Collections;
using UnityEngine;

namespace UnitySus2021.Sample06 {
    public class CharacterMover : MonoBehaviour {
        private MazeSearcher m_mazeSearcher;
        [SerializeField] private float m_moveSpeed = 2f;
        private IEnumerator m_moveCoroutine;

        private void Start() {
            m_mazeSearcher = FindObjectOfType<MazeSearcher>();

            m_moveCoroutine = MovePathCoroutine();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Return)) {
                StopCoroutine(m_moveCoroutine);
                m_moveCoroutine = null;
                m_moveCoroutine = MovePathCoroutine();
                StartCoroutine(m_moveCoroutine);
            }
        }


        //最短経路を移動させるコルーチン.
        private IEnumerator MovePathCoroutine() {
            transform.position = m_mazeSearcher.Path[0];

            for (int i = 1; i < m_mazeSearcher.Path.Count; i++) {
                while (true) {
                    var distance = m_mazeSearcher.Path[i] - (Vector2) transform.position;
                    var dir = distance.normalized;
                    transform.Translate(dir * m_moveSpeed * Time.deltaTime);
                    
                    //一定距離内になったら次へ進む.
                    if (distance.magnitude < 0.05f) {
                        transform.position = m_mazeSearcher.Path[i];
                        break;
                    }
                    yield return null;
                }
            }
        }
    }
}