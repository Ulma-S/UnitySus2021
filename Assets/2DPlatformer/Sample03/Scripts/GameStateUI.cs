using UnityEngine;
using UnityEngine.UI;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// ゲームの状態を表すUIを制御するクラス.
    /// </summary>
    public class GameStateUI : MonoBehaviour {
        [SerializeField] private Image m_panel;
        [SerializeField] private Image m_gameClear;
        [SerializeField] private Image m_gameOver;
        
        private void Update() {
            //ゲームクリアなら
            if (GameManager.GameState == EGameState.GameClear) {
                m_panel.gameObject.SetActive(true);
                m_gameClear.gameObject.SetActive(true);
            }
            //ゲームオーバーなら
            else if (GameManager.GameState == EGameState.GameOver) {
                m_panel.gameObject.SetActive(true);
                m_gameOver.gameObject.SetActive(true);
            }
        }
    }
}