namespace PotterShoppingCart.Entity
{
    /// <summary>
    /// 系列書籍
    /// </summary>
    public enum Serial
    {
        /// <summary>
        /// 非系列書
        /// </summary>
        None,

        /// <summary>
        /// 哈利波特
        /// </summary>
        HarryPotter,
    }

    /// <summary>
    /// 書籍
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 書名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 定價
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        public Serial Serial { get; set; }

        /// <summary>
        /// 覆寫Equals方法, 以Name判斷是否同一本書
        /// TODO: (待確認需求: 是否應改用ISBN)
        /// </summary>
        /// <param name="obj">比對目標</param>
        /// <returns>是否相等</returns>
        public override bool Equals(object obj)
        {
            Book target = obj as Book;
            if (target == null)
            {
                return false;
            }

            return string.Compare(this.Name, target.Name, true) == 0;
        }

        /// <summary>
        /// 覆寫GetHashCode方法, 以Name取得HashCode
        /// TODO: (待確認需求: 是否應改用ISBN)
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}