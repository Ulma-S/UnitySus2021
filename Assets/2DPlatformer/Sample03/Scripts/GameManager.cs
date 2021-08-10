using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public enum EGameStatus {
        Play,
        GameClear,
        GameOver,
    }
    
    public class GameManager : MonoBehaviour {
        [SerializeField] private PlayerStatus m_playerStatus;
        [SerializeField] private EnemyStatus m_enemyStatus;
        public static EGameStatus GameStatus { get; set; } = EGameStatus.Play;
        
        private void Awake() {
            //キーボード入力の参照をServiceLocatorに登録する.
            var obj = Resources.Load<KeyboardInputProvider>("KeyboardInputProvider");
            var instance = Instantiate(obj);
            Locator.Register<IInputProvider>(instance);
            
            //PlayerStatusを登録する.
            Locator.Register(m_playerStatus);
            
            //EnemyStatusを登録する.
            Locator.Register(m_enemyStatus);
        }
    }
}