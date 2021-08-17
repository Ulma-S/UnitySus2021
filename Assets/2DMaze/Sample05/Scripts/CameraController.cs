using UnityEngine;

namespace UnitySus2021.Sample05 {
    /// <summary>
    /// 迷路の大きさに応じたカメラの位置を設定するクラス.
    /// </summary>
    public class CameraController : MonoBehaviour {
        private MazeGenerator m_mazeGenerator;

        private void Start() {
            m_mazeGenerator = FindObjectOfType<MazeGenerator>();

            transform.position = new Vector3(m_mazeGenerator.MapData[0].Count/2f, -m_mazeGenerator.MapData.Count/2f, -10f);
        }
    }
}