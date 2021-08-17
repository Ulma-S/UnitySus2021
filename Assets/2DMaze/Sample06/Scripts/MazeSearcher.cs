using System.Collections.Generic;
using UnityEngine;
using UnitySus2021.Sample05;

namespace UnitySus2021.Sample06 {
    /// <summary>
    /// 迷路の経路を探索するクラス.
    /// </summary>
    public class MazeSearcher : MonoBehaviour {
        /// <summary>
        /// 迷路のマスごとの状態.
        /// </summary>
        private enum EMazeStatus {
            Open,
            Close,
            Wall,
            Start,
            Goal,
        }
        
        private MazeGenerator m_mazeGenerator;
        private readonly List<List<int>> m_mazeData = new List<List<int>>();
        private readonly List<List<EMazeStatus>> m_mazeStatus = new List<List<EMazeStatus>>();
        
        //探索中のパスを保持するリスト.
        private readonly List<Vector2> m_tmpPath = new List<Vector2>();
        
        //最短経路を格納するリスト.
        private List<Vector2> m_path = new List<Vector2>();
        public IReadOnlyList<Vector2> Path => m_path;
        
        private void Start() {
            m_mazeGenerator = FindObjectOfType<MazeGenerator>();

            var start = new Vector2Int();
            
            //各種リストの初期化.
            for (int i = 0; i < m_mazeGenerator.MapData.Count; i++) {
                m_mazeData.Add(new List<int>());
                m_mazeStatus.Add(new List<EMazeStatus>());
                
                for (int j = 0; j < m_mazeGenerator.MapData[0].Count; j++) {
                    m_mazeData[i].Add(m_mazeGenerator.MapData[i][j]);
                    
                    switch (m_mazeData[i][j]) {
                        case 0:
                            m_mazeStatus[i].Add(EMazeStatus.Open);
                            break;
                        case 1:
                            m_mazeStatus[i].Add(EMazeStatus.Wall);
                            break;
                        case 2:
                            m_mazeStatus[i].Add(EMazeStatus.Start);
                            start = new Vector2Int(j, i);
                            break;
                        case 3:
                            m_mazeStatus[i].Add(EMazeStatus.Goal);
                            break;
                    }
                }
            }

            SearchRoot(start.x, start.y);
        }

        
        /// <summary>
        /// 最短経路を検索するメソッド.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SearchRoot(int x, int y) {
            //次の座標.
            int nx, ny;

            if (x < 0 && x >= m_mazeStatus[0].Count && y < 0 && y >= m_mazeStatus.Count) {
                return;
            }

            //ゴールしたら経路をリストに格納する.
            if (m_mazeStatus[y][x] == EMazeStatus.Goal) {
                for (int i = 0; i < m_mazeStatus.Count; i++) {
                    for (int j = 0; j < m_mazeStatus[0].Count; j++) {
                        if (m_mazeStatus[i][j] == EMazeStatus.Close) {
                            m_path = new List<Vector2>(m_tmpPath);
                        }
                    }
                }
                m_path.Add(new Vector2(x, -y));
                return;
            }

            m_mazeStatus[y][x] = EMazeStatus.Close;
            m_tmpPath.Add(new Vector2(x, -y));

            //上に移動.
            nx = x;
            ny = y - 1;
            if (ny >= 0) {
                if (m_mazeStatus[ny][nx] != EMazeStatus.Close && m_mazeStatus[ny][nx] != EMazeStatus.Wall) {
                    SearchRoot(nx, ny);
                }
            }

            //下に移動.
            nx = x;
            ny = y + 1;
            if (ny < m_mazeStatus.Count) {
                if (m_mazeStatus[ny][nx] != EMazeStatus.Close && m_mazeStatus[ny][nx] != EMazeStatus.Wall) {
                    SearchRoot(nx, ny);
                }
            }

            //左に移動.
            nx = x - 1;
            ny = y;
            if (nx >= 0) {
                if (m_mazeStatus[ny][nx] != EMazeStatus.Close && m_mazeStatus[ny][nx] != EMazeStatus.Wall) {
                    SearchRoot(nx, ny);
                }
            }

            //右に移動.
            nx = x + 1;
            ny = y;
            if (nx < m_mazeStatus[0].Count) {
                if (m_mazeStatus[ny][nx] != EMazeStatus.Close && m_mazeStatus[ny][nx] != EMazeStatus.Wall) {
                    SearchRoot(nx, ny);
                }
            }

            //経路でなかった場合リストから取り除く.
            m_mazeStatus[y][x] = EMazeStatus.Open; 
            m_tmpPath.Remove(new Vector2(x, -y));
        }
    }
}