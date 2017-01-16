using System;
using System.Linq;
using PotterShoppingCart.Domain;
using PotterShoppingCart.Entity;
using PotterShoppingCart.Interface;

namespace PotterShoppingCart.Service
{
    public class ShoppingCartService
    {
        public ShoppingCartService()
        {
        }

        /// <summary>
        /// 依據哈利波特系列書的購買套數(2本以上不重複就算)計算折扣後的總金額, 不成套以原價計算        
        /// </summary>
        /// <param name="order">訂單</param>
        /// <returns>總金額</returns>
        public decimal GetPotterSerialTotalPrice(Order order)
        {
            decimal totalPrice = 0;

            //以while逐一取得每套不重複書籍數量計算金額, 直至套數超過最大單本數量
            int pack = 1;
            while (order.Details.Values.Any(p => p >= pack))
            {
                var bookInPack = order.Details.Where(p => p.Value >= pack);

                //以每套中的書籍數量取得對應折扣數, 並計算該套金額加總至總額
                totalPrice += bookInPack.Sum(p => p.Key.Price) * GetDisount(bookInPack.Count());

                pack++;
            }
            
            return totalPrice;
        }

        /// <summary>
        /// 依據每套中的書籍數量取得對應折扣的類別以取得折扣數
        /// </summary>
        /// <param name="countInPack">每套中的書籍數量</param>
        /// <returns>折扣數</returns>
        private decimal GetDisount(int countInPack)
        {
            IDiscount discount = null;

            switch (countInPack)
            {
                case 1:
                    discount = new PackOf1PotterDiscount();
                    break;

                case 2:
                    discount = new PackOf2PotterDiscount();
                    break;

                case 3:
                    discount = new PackOf3PotterDiscount();
                    break;

                case 4:
                    discount = new PackOf4PotterDiscount();
                    break;

                case 5:
                    discount = new PackOf5PotterDiscount();
                    break;
            }

            return discount.GetDiscount();
        }
    }
}