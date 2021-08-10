using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    public class PlayerJumpState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        private IInputProvider m_inputProvider;
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        private float m_jumpForce;
        private bool m_isGround = false;
        
        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Jump, this);

            m_inputProvider = Locator.Resolve<IInputProvider>();

            m_jumpForce = Locator.Resolve<PlayerStatus>().JumpForce;
        }

        public override void OnEnter() {
            if (m_isGround) {
                Jump();
            }
            else {
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
        }

        public override void OnUpdate() {
        }

        public override void OnExit() {
            m_animator.SetBool(IsJump, false);
        }

        private void Jump() {
            var dir = 0.0f;
            if (m_inputProvider.HorizontalInput > 0.0f) {
                dir = 1.0f;
            }else if (m_inputProvider.HorizontalInput < 0.0f) {
                dir = -1.0f;
            }
            m_rb.AddForce(new Vector2(1.0f * dir, 3.0f).normalized * m_jumpForce);
            
            m_animator.SetBool(IsJump, true);
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Enemy")) {
                m_isGround = true;
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
        }
    }
}