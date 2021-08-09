using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerMoveState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        [SerializeField] private PlayerStatus m_playerStatus;
        private IInputProvider m_inputProvider;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        
        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Move, this);

            m_inputProvider = Locator.Resolve<IInputProvider>();
        }

        public override void OnEnter() {
        }

        public override void OnUpdate() {
            Move();
            
            //移動入力の終了時IdleStateに遷移する.
            if (Mathf.Abs(m_inputProvider.HorizontalInput) <= 0.001f) {
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
            
            ApplyDirection();
            ApplyLocalGravity();
        }

        public override void OnExit() {
            m_animator.SetFloat(Speed, 0f);
        }

        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_playerStatus.MoveSpeed * m_inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
            
            m_animator.SetFloat(Speed, m_rb.velocity.x);
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