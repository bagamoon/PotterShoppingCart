using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Entity.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void Test_Add_1_Book_Count_Is_1()
        {
            Book book = new Book { Name = "A", Price = 100, Serial = Serial.None };

            int expected = 1;

            var target = new Order();
            target.AddBook(book, 1);

            int actual = target.Details.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}