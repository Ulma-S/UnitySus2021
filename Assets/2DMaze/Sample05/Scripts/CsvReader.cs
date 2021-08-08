using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnitySus2021.Sample05 {
    /// <summary>
    /// CSVファイルを読み込むクラス.
    /// </summary>
    public class CsvReader : MonoBehaviour {
        /// <summary>
        /// CSVファイルを読み込むメソッド.
        /// </summary>
        /// <returns></returns>
        public List<string[]> Load(string fileName = "UnitySus2021") {
            var csvFile = Resources.Load<TextAsset>(fileName);
            var output = new List<string[]>();
            var reader = new StringReader(csvFile.text);
            while (reader.Peek() > -1) {
                var line = reader.ReadLine();
                output.Add(line.Split(','));
            }
            return output;
        }    
    }
}