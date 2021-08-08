using System.Collections.Generic;
using UnityEngine;

namespace UnitySus2021.Sample05 {
    public class MazeGenerator : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_mapTile;
        
        private void Start() {
            var csvReader = FindObjectOfType<CsvReader>();
            
            var csvData = new List<string[]>(csvReader.Load());
            
            GenerateMap(csvData);
        }

        /// <summary>
        /// CSVデータに基づきマップを生成するメソッド.
        /// </summary>
        /// <param name="data"></param>
        private void GenerateMap(List<string[]> data) {
            if (data == null) {
                return;
            }
            
            var width = data[0].Length;
            var height = data.Count;

            if (width <= 0 || height <= 0) {
                return;
            }
            
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (data[i][j] == "1") {
                        var obj = Instantiate(m_mapTile, new Vector3(j, -i, 0f), Quaternion.identity);
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }
}