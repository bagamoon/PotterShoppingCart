using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Entity;
using PotterShoppingCart.Service;

namespace PotterShoppingCart.Tests.Service
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
            hp1 = new Book { Name = "HP1", Price = 100 };
            hp2 = new Book { Name = "HP2", Price = 100 };
            hp3 = new Book { Name = "HP3", Price = 100 };
            hp4 = new Book { Name = "HP4", Price = 100 };
            hp5 = new Book { Name = "HP5", Price = 100 };
        }

        [TestCleanup()]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void Test_Buy_1_Book1_Total_Is_100()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 }
                                                };

            var order = new Order(details);            

            int expected = 100;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_Total_Is_190()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 1 }
                                                };

            var order = new Order(details);

            int expected = 190;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_Total_Is_270()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 1 },
                                                    { hp3, 1 }
                                                };

            var order = new Order(details);

            int expected = 270;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_1_Book4_Total_Is_320()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 1 },
                                                    { hp3, 1 },
                                                    { hp4, 1 }
                                                };

            var order = new Order(details);

            int expected = 320;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_Each_From_Book1_To_Book5_Is_375()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 1 },
                                                    { hp3, 1 },
                                                    { hp4, 1 },
                                                    { hp5, 1 }
                                                };

            var order = new Order(details);

            int expected = 375;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_2_Book3_Total_Is_370()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 1 },
                                                    { hp3, 2 }
                                                };

            var order = new Order(details);

            int expected = 370;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_2_Book2_2_Book3_Total_Is_460()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 1 },
                                                    { hp2, 2 },
                                                    { hp3, 2 }
                                                };

            var order = new Order(details);

            int expected = 460;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_101_Book1_1_Book2_Total_Is_10190()
        {
            Dictionary<Book, int> details = new Dictionary<Book, int>
                                                {
                                                    { hp1, 101 },
                                                    { hp2, 1 }                                                    
                                                };

            var order = new Order(details);

            int expected = 10190;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Empty_Order_Is_0()
        {
            var order = new Order();

            int expected = 0;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }
    }
}