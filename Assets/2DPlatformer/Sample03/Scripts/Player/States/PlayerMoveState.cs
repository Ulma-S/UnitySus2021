using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの移動Stateを制御するクラス.
    /// </summary>
    public class PlayerMoveState : PlayerStateBase {
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private float m_moveSpeed;

        protected override void Initialize() {
            //Stateの登録.
            stateMachine.RegisterState(EPlayerStateType.Run, this);
            
            m_moveSpeed = playerStatus.MoveSpeed;
        }

        public override void OnEnter() {
        }

        public override void OnUpdate() {
            //移動の更新.
            Move();

            //ジャンプボタンが入力されたらJumpStateに遷移する.
            if (inputProvider.IsJumpPressed) {
                stateMachine.ChangeState(EPlayerStateType.Jump);
            }
            
            //移動入力の終了時IdleStateに遷移する.
            if (Mathf.Abs(inputProvider.HorizontalInput) <= 0.001f) {
                stateMachine.ChangeState(EPlayerStateType.Idle);
            }
            
            //攻撃ボタンが入力されたらAttackStateに遷移する.
            if (inputProvider.IsAttackPressed) {
                stateMachine.ChangeState(EPlayerStateType.Attack);
            }
            
            //方向の更新.
            ApplyDirection();
        }

        public override void OnExit() {
            //速度を0にする.
            var velocity = m_rb.velocity;
            velocity.x = 0f;
            m_rb.velocity = velocity;
        }

        /// <summary>
        /// 移動用メソッド.
        /// </summary>
        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_moveSpeed * inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
            
            //AnimatorのSpeed変数に0を設定する.
            m_animator.SetFloat(Speed, Mathf.Abs(m_rb.velocity.x));
        }

        private void Reset() {
            m_animator = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
        }
    }
}