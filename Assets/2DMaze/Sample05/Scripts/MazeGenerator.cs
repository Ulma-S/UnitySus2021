using System.Collections.Generic;
using UnityEngine;

namespace UnitySus2021.Sample05 {
    public class MazeGenerator : MonoBehaviour {
        [SerializeField] private SpriteRenderer m_mapTile;
        private List<List<int>> m_mapData;
        public IReadOnlyList<IReadOnlyList<int>> MapData => m_mapData;
        
        private void Awake() {
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
            
            m_mapData = new List<List<int>>();
            for (int i = 0; i < height; i++) {
                m_mapData.Add(new List<int>());
            }

            if (width <= 0 || height <= 0) {
                return;
            }
            
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (data[i][j] == "1") {
                        var obj = Instantiate(m_mapTile, new Vector3(j, -i, 0f), Quaternion.identity);
                        obj.transform.parent = transform;
                        m_mapData[i].Add(1);
                    }
                    else if(data[i][j] == "0"){
                        m_mapData[i].Add(0);
                    }
                    else if (data[i][j] == "2") {
                        m_mapData[i].Add(2);
                    }
                    else if (data[i][j] == "3") {
                        m_mapData[i].Add(3);
                    }
                }
            }
        }
    }
}