using UnityEngine;
using UnitySus2021.InputSystem;

namespace UnitySus2021.Sample01 {
    /// <summary>
    /// Playerの移動を管理するクラス.
    /// </summary>
    public class PlayerMover : MonoBehaviour {
        [SerializeField] private Rigidbody2D m_rb;
        [SerializeField] private Animator m_animator;
        private KeyboardInputProvider m_inputProvider;

        // Playerのステータスを設定 //
        [SerializeField] private float m_moveSpeed = 2f;
        [SerializeField] private float m_jumpForce = 300f;
        [SerializeField] private float m_localGravityScale = 2f;
        // --------------------- //
        
        /// <summary>
        /// 接地しているか?
        /// </summary>
        private bool m_isGround = false;
        
        //Animationハッシュ値
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsJump = Animator.StringToHash("IsJump");

        private void Start() {
            m_inputProvider = FindObjectOfType<KeyboardInputProvider>();
        }

        private void Update() {
            //移動の更新.
            Move();
            
            //地上にいるときジャンプが入力されたらジャンプする.
            if (m_inputProvider.IsJumpPressed && m_isGround) {
                Jump();
            }
            
            //方向の更新.
            ApplyDirection();
            
            //重力の更新.
            ApplyLocalGravity();
        }

        
        /// <summary>
        /// 移動メソッド.
        /// </summary>
        private void Move() {
            var velocity = m_rb.velocity;
            velocity.x = m_moveSpeed * m_inputProvider.HorizontalInput;
            m_rb.velocity = velocity;
            
            //AnimatorのSpeedに速度を渡す.
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
            m_rb.AddForce(new Vector2(1.0f * dir, 3.0f).normalized * m_jumpForce);
            
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
        /// 重力を反映するメソッド.
        /// </summary>
        private void ApplyLocalGravity() {
            var velocity = m_rb.velocity;
            velocity.y -= m_localGravityScale * Time.deltaTime;
            m_rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            //PlayerとGroundが衝突した時
            if (other.gameObject.CompareTag("Ground")) {
                //落下中なら
                if (m_rb.velocity.y <= 0f) {
                    //接地判定をtrueにする.
                    m_isGround = true;
                    m_animator.SetBool(IsJump, false);
                }
            }
        }

        private void Reset() {
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }
    }
}