using System;
using System.Linq;
using PotterShoppingCart.Entity;

namespace PotterShoppingCart.Service
{
    public class ShoppingCartService
    {
        public ShoppingCartService()
        {
        }

        /// <summary>
        /// 依據哈利波特系列書的購買套數(2本以上不重複就算)計算折扣後的總金額, 不成套以原價計算
        /// 計算結果以無條件捨去至整數位回傳
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

                switch (bookInPack.Count())
                {
                    case 1:
                        totalPrice += bookInPack.First().Key.Price;
                        break;

                    case 2:
                        totalPrice += bookInPack.Sum(p => p.Key.Price) * 0.95M;
                        break;

                    case 3:
                        totalPrice += bookInPack.Sum(p => p.Key.Price) * 0.9M;
                        break;

                    case 4:
                        totalPrice += bookInPack.Sum(p => p.Key.Price) * 0.8M;
                        break;

                    case 5:
                        totalPrice += bookInPack.Sum(p => p.Key.Price) * 0.75M;
                        break;
                }

                pack++;
            }

            //佛心老闆使用無條件捨去
            return Math.Floor(totalPrice);
        }
    }
}