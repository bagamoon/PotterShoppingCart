using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PotterShoppingCart.Entity
{
    /// <summary>
    /// 訂單
    /// </summary>
    public class Order
    {
        public Order()
        {
            _details = new Dictionary<Book, int>();
        }

        /// <summary>
        /// constructor for test case
        /// </summary>
        /// <param name="details"></param>
        public Order(Dictionary<Book,int> details)
        {
            _details = details;
        }

        /// <summary>
        /// 訂單明細資料, Key: Book, Value: 該書購買數量
        /// </summary>
        private Dictionary<Book, int> _details;

        /// <summary>
        /// 訂單明細資料(readonly), Key: Book, Value: 該書購買數量
        /// </summary>
        public ReadOnlyDictionary<Book, int> Details
        {
            get
            {
                return new ReadOnlyDictionary<Book, int>(_details);
            }
        }

        /// <summary>
        /// 於訂單中加入欲購買的書籍
        /// </summary>
        /// <param name="book">書籍</param>
        /// <param name="count">購買數量</param>
        public void AddBook(Book book, int count)
        {
            if (_details.ContainsKey(book))
            {
                _details[book] += count;
            }
            else
            {
                _details.Add(book, count);
            }
        }
    }
}