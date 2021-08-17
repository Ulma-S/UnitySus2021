using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Enemyの上に表示するUIのCanvasを制御するクラス.
    /// </summary>
    public class EnemyUICanvasView : MonoBehaviour {
        private void Update() {
            //方向の更新.
            ApplyLocalScale();
        }

        //親のlocalScaleを無視する.
        private void ApplyLocalScale() {
            var parentLocalScale = transform.parent.localScale;
            var localScale = transform.localScale;
            if (parentLocalScale.x > 0f) {
                localScale.x = Mathf.Abs(localScale.x);
            }else if (parentLocalScale.x < 0f) {
                localScale.x = -Mathf.Abs(localScale.x);
            }
            transform.localScale = localScale;
        }
    }
}