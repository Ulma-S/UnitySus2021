using UnityEngine;

namespace UnitySus2021.Sample04 {
    public class MazeGenerator : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_mapTile;
        
        private readonly int[,] m_mapData = {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 1,},
            {1, 0, 1, 1, 0, 0, 0, 1, 0, 1,},
            {1, 0, 0, 1, 1, 1, 1, 0, 0, 1,},
            {1, 1, 0, 1, 0, 0, 1, 1, 1, 1,},
            {1, 1, 0, 0, 0, 1, 0, 0, 0, 1,},
            {1, 0, 0, 1, 0, 1, 0, 1, 0, 1,},
            {1, 0, 1, 1, 1, 0, 0, 1, 0, 1,},
            {1, 0, 0, 0, 0, 0, 1, 1, 0, 1,},
            {1, 1, 1, 1, 1, 1, 1, 1, 0, 1,},
        };
    
        private void Start() {
            GenerateMap();
        }

        private void GenerateMap() {
            var height = m_mapData.GetLength(0);
            var width = m_mapData.Length / height;
            
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (m_mapData[i, j] == 1) {
                        var obj = Instantiate(m_mapTile, new Vector3(j, -i, 0f), Quaternion.identity);
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }
}