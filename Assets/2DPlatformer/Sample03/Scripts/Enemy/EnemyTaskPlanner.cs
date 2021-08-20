using UnityEngine;

namespace UnitySus2021.Sample03 {
    /// <summary>
    /// EnemyのTaskの種類.
    /// </summary>
    public enum EEnemyTaskType {
        Idle,
        Run,
        WeakAttack,
        StrongAttack,
    }
    
    /// <summary>
    /// EnemyのTaskのプランニングをするクラス.
    /// </summary>
    public class EnemyTaskPlanner : MonoBehaviour {
        [SerializeField] private EnemyRangeController m_rangeController;
        private readonly ITaskSystem<EEnemyTaskType> m_taskSystem = new TaskSystem<EEnemyTaskType>();
        
        private void Start() {
            //Taskの登録.
            m_taskSystem.RegisterTask(new EnemyIdleTask(gameObject));
            m_taskSystem.RegisterTask(new EnemyRunTask(gameObject));
            m_taskSystem.RegisterTask(new EnemyWeakAttackTask(gameObject));
            m_taskSystem.RegisterTask(new EnemyStrongAttackTask(gameObject));
            
            //Taskの設定.
            m_taskSystem.EnqueueTask(EEnemyTaskType.Idle);
        }

        private void Update() {
            if (GameManager.GameState == EGameState.Play) {
                //Taskがすべて終了したら新たにTaskを入れる.
                if (m_taskSystem.IsEndAllTasks) {
                    SelectTask();
                }

                //Taskの更新.
                m_taskSystem.UpdateTask();
            }
        }
        
        /// <summary>
        /// Taskの選択をするメソッド.
        /// (ここを変えると敵の攻撃パターンを変えられます.)
        /// </summary>
        private void SelectTask() {
            //Playerが範囲内にいる場合
            if (m_rangeController.IsInRange) {
                //前回が攻撃なら待機する.
                if (m_taskSystem.PrevTaskType == EEnemyTaskType.WeakAttack) {
                    m_taskSystem.EnqueueTask(EEnemyTaskType.Idle);
                }
                else if(m_taskSystem.PrevTaskType == EEnemyTaskType.StrongAttack) {
                    m_taskSystem.EnqueueTask(EEnemyTaskType.Idle);
                    m_taskSystem.EnqueueTask(EEnemyTaskType.Idle);
                }
                //それ以外ならランダムで攻撃を選択する.
                else {
                    var random = Random.Range(0, 2);
                    if (random < 1) {
                        m_taskSystem.EnqueueTask(EEnemyTaskType.WeakAttack);
                    }
                    else {
                        m_taskSystem.EnqueueTask(EEnemyTaskType.StrongAttack);
                    }
                }
            }
            //範囲外ならPlayerに向かって移動する.
            else {
                m_taskSystem.EnqueueTask(EEnemyTaskType.Run);
            }
        }

        //デバッグ用.
#if UNITY_EDITOR
        private void OnGUI() {
            //現在と前回のTaskの種類を出力.
            GUILayout.Label("Current:" + m_taskSystem.CurrentTaskType + ", prev:" + m_taskSystem.PrevTaskType);
        }
#endif
    }
}