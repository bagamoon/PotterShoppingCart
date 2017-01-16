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
            var order = new Order();
            order.Details.Add(hp1, 1);

            int expected = 100;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_Total_Is_190()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 1);

            int expected = 190;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_Total_Is_270()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 1);
            order.Details.Add(hp3, 1);

            int expected = 270;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_1_Book3_1_Book4_Total_Is_320()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 1);
            order.Details.Add(hp3, 1);
            order.Details.Add(hp4, 1);

            int expected = 320;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_Each_From_Book1_To_Book5_Is_375()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 1);
            order.Details.Add(hp3, 1);
            order.Details.Add(hp4, 1);
            order.Details.Add(hp5, 1);

            int expected = 375;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_1_Book2_2_Book3_Total_Is_370()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 1);
            order.Details.Add(hp3, 2);

            int expected = 370;

            var target = new ShoppingCartService();
            decimal actual = target.GetPotterSerialTotalPrice(order);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book1_2_Book2_2_Book3_Total_Is_460()
        {
            var order = new Order();
            order.Details.Add(hp1, 1);
            order.Details.Add(hp2, 2);
            order.Details.Add(hp3, 2);

            int expected = 460;

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