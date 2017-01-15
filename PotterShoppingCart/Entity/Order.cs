using System;
using System.Collections.Generic;

namespace PotterShoppingCart.Entity
{
    public class Order
    {
        public Order()
        {
            Details = new Dictionary<Book, int>();
        }

        public Dictionary<Book, int> Details { get; private set; }

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