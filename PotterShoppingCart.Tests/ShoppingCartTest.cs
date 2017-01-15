﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Entity;
using PotterShoppingCart.Service;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        private Book hp1;
        private Book hp2;
        private Book hp3;
        private Book hp4;
        private Book hp5;

        [TestInitialize()]
        public void TestInitialize()
        {
            hp1 = new Book { Name = "HP1", Price = 100, Serial = Serial.HarryPotter };
            hp2 = new Book { Name = "HP2", Price = 100, Serial = Serial.HarryPotter };
            hp3 = new Book { Name = "HP3", Price = 100, Serial = Serial.HarryPotter };
            hp4 = new Book { Name = "HP4", Price = 100, Serial = Serial.HarryPotter };
            hp5 = new Book { Name = "HP5", Price = 100, Serial = Serial.HarryPotter };
        }

        [TestCleanup()]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void Test_Buy_1_Book1_Total_Is_100()
        {
            var order = new Order();
            order.AddBook(hp1, 1);

            int expected = 100;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_Total_Is_190()
        {
            var order = new Order();
            order.AddBook(hp1, 1);
            order.AddBook(hp2, 1);

            int expected = 190;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_Total_Is_270()
        {
            var order = new Order();
            order.AddBook(hp1, 1);
            order.AddBook(hp2, 1);
            order.AddBook(hp3, 1);

            int expected = 270;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_1_Book4_Total_Is_320()
        {
            var order = new Order();
            order.AddBook(hp1, 1);
            order.AddBook(hp2, 1);
            order.AddBook(hp3, 1);
            order.AddBook(hp4, 1);

            int expected = 320;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_Each_From_Book1_To_Book5_Is_375()
        {
            var order = new Order();
            order.AddBook(hp1, 1);
            order.AddBook(hp2, 1);
            order.AddBook(hp3, 1);
            order.AddBook(hp4, 1);
            order.AddBook(hp5, 1);

            int expected = 375;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }
    }
}