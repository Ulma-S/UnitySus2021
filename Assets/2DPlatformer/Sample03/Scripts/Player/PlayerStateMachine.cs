using System.Collections.Generic;
using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの状態の種類.
    /// </summary>
    public enum EPlayerStateType {
        None,
        Idle,
        Run,
        Jump,
        Attack,
        Death,
    }
    
    /// <summary>
    /// PlayerのState(状態)を管理するクラス (Stateパターン).
    /// </summary>
    public class PlayerStateMachine : MonoBehaviour {
        /// <summary>
        /// 全ての状態を格納する連想配列.
        /// </summary>
        private readonly Dictionary<EPlayerStateType, PlayerStateBase> m_stateMap = new Dictionary<EPlayerStateType, PlayerStateBase>();
        
        /// <summary>
        /// 現在の状態の種類.
        /// </summary>
        public EPlayerStateType CurrentStateType { get; private set; } = EPlayerStateType.None;

        /// <summary>
        /// 現在の状態.
        /// </summary>
        private PlayerStateBase m_currentState {
            get {
                if (m_stateMap.ContainsKey(CurrentStateType)) {
                    return m_stateMap[CurrentStateType];
                }
                return null;
            }
        }

        private void Start() {
            m_stateMap.Add(EPlayerStateType.None, null);
        }

        private void Update() {
            //現在のStateを更新する.
            if (m_currentState != null) {
                if (GameManager.GameState == EGameState.Play) {
                    m_currentState.OnUpdate();
                }
            }
        }


        /// <summary>
        /// Stateを遷移するメソッド.
        /// </summary>
        /// <param name="nextStateType"></param>
        public void ChangeState(EPlayerStateType nextStateType) {
            //遷移先のStateが登録されていなかったら何もしない.
            if (!m_stateMap.ContainsKey(nextStateType)) { 
                return;
            }

            var nextState = m_stateMap[nextStateType];
            //遷移先のStateがnullなら何もしない.
            if (nextState == null) {
                return;
            }

            if (m_currentState != null) {
                m_currentState.OnExit();
            }
            CurrentStateType = nextStateType;
            nextState.OnEnter();
        }

        
        /// <summary>
        /// Stateを登録するメソッド.
        /// </summary>
        /// <param name="stateType"></param>
        /// <param name="state"></param>
        public void RegisterState(EPlayerStateType stateType, PlayerStateBase state) {
            if (m_stateMap.ContainsKey(stateType)) {
                //既に登録されているなら何もしない.
                return;
            }
            m_stateMap.Add(stateType, state);
        }
    }
}