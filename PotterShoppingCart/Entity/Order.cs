using System;
using System.Collections.Generic;

namespace PotterShoppingCart.Entity
{
    /// <summary>
    /// 訂單
    /// </summary>
    public class Order
    {
        public Order()
        {
            Details = new Dictionary<Book, int>();
        }

        /// <summary>
        /// 訂單明細資料, Key: Book, Value: 該書購買數量
        /// </summary>
        public Dictionary<Book, int> Details { get; private set; }

        /// <summary>
        /// 於訂單中加入欲購買的書籍
        /// </summary>
        /// <param name="book">書籍</param>
        /// <param name="count">購買數量</param>
        public void AddBook(Book book, int count)
        {
            if (Details.ContainsKey(book))
            {
                Details[book] += count;
            }
            else
            {
                Details.Add(book, count);
            }
        }
    }
}