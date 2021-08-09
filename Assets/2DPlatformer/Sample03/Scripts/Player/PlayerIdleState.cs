using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerIdleState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        [SerializeField] private PlayerStatus m_playerStatus;
        private IInputProvider m_inputProvider;
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Idle, this);

            m_inputProvider = Locator.Resolve<IInputProvider>();
            
            stateMachine.ChangeState(EPlayerStateType.Idle);
        }

        public override void OnEnter() {
        }

        public override void OnUpdate() {
            //移動が入力されたらMoveStateに遷移する.
            if (Mathf.Abs(m_inputProvider.HorizontalInput) > 0f) {
                stateMachine.ChangeState(EPlayerStateType.Move);
            }
            
            //攻撃ボタンが押されたらAttackStateに遷移する.
            if (m_inputProvider.IsAttackPressed) {
                stateMachine.ChangeState(EPlayerStateType.Attack);
            }
            
            ApplyDirection();
            ApplyLocalGravity();
        }

        public override void OnExit() {
        }
        
        /// <summary>
        /// 方向を反映するメソッド.
        /// </summary>
        private void ApplyDirection() {
            var localScale = transform.localScale;
            if (m_inputProvider.HorizontalInput > 0.0f) {
                localScale.x = Mathf.Abs(localScale.x);
            }else if (m_inputProvider.HorizontalInput < 0.0f) {
                localScale.x = -Mathf.Abs(localScale.x);
            }
            transform.localScale = localScale;
        }


        /// <summary>
        /// 重力を反映する.
        /// </summary>
        private void ApplyLocalGravity() {
            var velocity = m_rb.velocity;
            velocity.y -= m_playerStatus.LocalGravityScale * Time.deltaTime;
            m_rb.velocity = velocity;
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
        }
    }
}