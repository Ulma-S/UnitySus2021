using UnityEngine;

namespace UnitySus2021.Sample03 {
    public abstract class PlayerStateBase : MonoBehaviour {
        protected PlayerStateMachine stateMachine;

        private void Start() {
            stateMachine = GetComponent<PlayerStateMachine>();
            Initialize();
        }

        /// <summary>
        /// Start関数の代用メソッド.
        /// Start関数をvirtualにすると、派生クラスでbase.Start()のように呼び出す必要があるが、
        /// これはミスを誘発する点で好ましくない.
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
    }
}