using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerMoveState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        private IInputProvider m_inputProvider;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private float m_moveSpeed;

        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Run, this);

            m_inputProvider = Locator.Resolve<IInputProvider>();

            m_moveSpeed = Locator.Resolve<PlayerStatus>().MoveSpeed;
        }

        public override void OnEnter() {
        }

        public override void OnUpdate() {
            Move();

            //ジャンプボタンが入力されたらJumpStateに遷移する.
            if (m_inputProvider.IsJumpPressed) {
                stateMachine.ChangeState(EPlayerStateType.Jump);
            }
            
            //移動入力の終了時IdleStateに遷移する.
            if (Mathf.Abs(m_inputProvider.HorizontalInput) <= 0.001f) {
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
            
            //攻撃ボタンが入力されたらAttackStateに遷移する.
            if (m_inputProvider.IsAttackPressed) {
                stateMachine.ChangeState(EPlayerStateType.Attack);
            }
            
            ApplyDirection();
        }

        public override void OnExit() {
            var velocity = m_rb.velocity;
            velocity.x = 0f;
            m_rb.velocity = velocity;
        }

        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_moveSpeed * m_inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
            
            m_animator.SetFloat(Speed, Mathf.Abs(m_rb.velocity.x));
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

        private void Reset() {
            m_animator = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
        }
    }
}