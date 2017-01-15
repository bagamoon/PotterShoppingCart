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
    }
}