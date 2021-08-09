using UnityEngine;
using UnitySus2021.InputSystem;
using UnitySus2021.Sample02;
using UnitySus2021.Util;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// Playerの移動を管理するメソッド.
    /// </summary>
    public class PlayerMover : MonoBehaviour { 
        [SerializeField] private Rigidbody2D m_rb;
        [SerializeField] private Animator m_animator;
        [SerializeField] private PlayerStatus m_playerStatus;
        private IInputProvider m_inputProvider;
        
        private bool m_isGround = false;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsJump = Animator.StringToHash("IsJump");

        private void Start() {
            //ServiceLocatorで依存を注入する.
            m_inputProvider = Locator.Resolve<IInputProvider>();
        }
        
        private void Update() {
            Move();
            
            //地上にいるときジャンプが入力されたらジャンプする.
            if (m_inputProvider.IsJumpPressed && m_isGround) {
                Jump();
            }
            
            ApplyDirection();
            ApplyLocalGravity();
        }

        
        /// <summary>
        /// 移動メソッド.
        /// </summary>
        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_playerStatus.MoveSpeed * m_inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
            
            m_animator.SetFloat(Speed, Mathf.Abs(m_rb.velocity.x));
        }

        
        /// <summary>
        /// ジャンプメソッド.
        /// </summary>
        private void Jump() {
            m_isGround = false;

            var dir = 0.0f;
            if (m_inputProvider.HorizontalInput > 0.0f) {
                dir = 1.0f;
            }else if (m_inputProvider.HorizontalInput < 0.0f) {
                dir = -1.0f;
            }
            m_rb.AddForce(new Vector2(1.0f * dir, 3.0f).normalized * m_playerStatus.JumpForce);
            
            m_animator.SetBool(IsJump, true);
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

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                m_isGround = true;
                m_animator.SetBool(IsJump, false);
            }
        }

        private void Reset() {
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }
    }
}