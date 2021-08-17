namespace UnitySus2021.Sample03 {
    /// <summary>
    /// ダメージ判定を提供するインターフェース.
    /// </summary>
    public interface IDamageable {
        /// <summary>
        /// ダメージを与えるメソッド.
        /// </summary>
        /// <param name="attackValue">攻撃側の攻撃力</param>
        void ApplyDamage(int attackValue);
    }
}