using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// PlayerのState用基底クラス.
    /// </summary>
    public abstract class PlayerStateBase : MonoBehaviour {
        /// <summary>
        /// StateMachineの参照.
        /// </summary>
        protected PlayerStateMachine stateMachine { get; private set; }
        
        /// <summary>
        /// Playerのステータス.
        /// </summary>
        protected PlayerStatus playerStatus { get; private set; }
        
        /// <summary>
        /// 入力の参照.
        /// </summary>
        protected IInputProvider inputProvider { get; private set; }

        private void Start() {
            stateMachine = GetComponent<PlayerStateMachine>();
            playerStatus = Locator.Resolve<PlayerStatus>();
            inputProvider = Locator.Resolve<IInputProvider>();
            Initialize();
        }

        /// <summary>
        /// Start関数の代用メソッド.
        /// (Start関数をvirtualにすると、派生クラスでbase.Start()のように呼び出す必要があるが、
        /// これはミスを誘発する点で好ましくない.)
        /// (Template Method パターン)
        /// </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Stateに入った時に呼ばれるメソッド.
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// Stateの更新メソッド.
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        /// Stateを出るときに呼ばれるメソッド.
        /// </summary>
        public abstract void OnExit();
        
        /// <summary>
        /// 方向を反映するメソッド.
        /// </summary>
        protected void ApplyDirection() {
            var localScale = transform.localScale;
            if (inputProvider.HorizontalInput > 0.0f) {
                localScale.x = Mathf.Abs(localScale.x);
            }else if (inputProvider.HorizontalInput < 0.0f) {
                localScale.x = -Mathf.Abs(localScale.x);
            }
            transform.localScale = localScale;
        }
    }
}