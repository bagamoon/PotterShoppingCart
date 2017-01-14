using System;
using System.Collections.Generic;

namespace PotterShoppingCart.Entity
{
    public class Order
    {
        public Order()
        {
        }

        public Dictionary<Book, int> Details { get; private set; }

        public void AddBook(Book book, int count)
        {
            throw new NotImplementedException();
        }
    }
}