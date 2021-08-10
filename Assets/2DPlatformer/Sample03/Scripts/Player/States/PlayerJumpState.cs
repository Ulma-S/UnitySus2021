using UnityEngine;

namespace UnitySus2021.Sample03 {
    public class PlayerJumpState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        private float m_jumpForce;
        private bool m_isGround = false;
        private float m_moveSpeed;
        
        protected override void Initialize() {
            stateMachine.RegisterState(EPlayerStateType.Jump, this);
            m_jumpForce = playerStatus.JumpForce;
            m_moveSpeed = playerStatus.MoveSpeed * 2f / 3f;
        }

        public override void OnEnter() {
            //着地しているならジャンプする.
            if (m_isGround) {
                Jump();
            }
            //空中にいるなら何もしない.
            else {
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
        }

        public override void OnUpdate() {
            //空中での移動.
            Move();
            ApplyDirection();
        }

        public override void OnExit() {
            m_animator.SetBool(IsJump, false);
        }

        private void Jump() {
            var dir = 0f;
            if (inputProvider.HorizontalInput > 0f) {
                dir = 1f;
            }else if (inputProvider.HorizontalInput < 0f) {
                dir = -1f;
            }
            m_rb.AddForce(new Vector2(1f * dir, 3f).normalized * m_jumpForce);
            
            m_animator.SetBool(IsJump, true);
        }

        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_moveSpeed * inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
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