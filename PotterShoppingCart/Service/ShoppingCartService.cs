using System.Collections.Generic;
using System.Linq;
using PotterShoppingCart.Entity;

namespace PotterShoppingCart.Service
{
    public class ShoppingCartService
    {
        /// <summary>
        /// 每套中的書籍數量與折扣數的對應, Key:書籍數量, Value:折扣數(小數), 70%將以0.7存放
        /// </summary>
        private Dictionary<int, decimal> _discountMap;

        public ShoppingCartService()
        {
            //20170118 改用dictionary以減少class數量, 待有需要以更複雜條件計算時再使用interface及class實作
            _discountMap = new Dictionary<int, decimal> {                                                            
                                                            { 2, 0.95M },
                                                            { 3, 0.9M },
                                                            { 4, 0.8M },
                                                            { 5, 0.75M }
                                                        };
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

                int bookCount = bookInPack.Count();
                //20170118 加入剩下都是不成套的判斷, 可直接用單價乘以數量
                if (bookCount == 1)
                {
                    //需扣掉前面已被成套計算過的數量
                    int calculatedPack = pack - 1;
                    totalPrice += bookInPack.Sum(p => p.Key.Price * (p.Value - calculatedPack));
                    break;
                }

                //以每套中的書籍數量取得對應折扣數, 並計算該套金額加總至總額
                totalPrice += bookInPack.Sum(p => p.Key.Price) * GetDisount(bookCount);

                pack++;
            }

            return totalPrice;
        }

        /// <summary>
        /// 依據每套中的書籍數量取得對應折扣的類別以取得折扣數
        /// </summary>
        /// <param name="bookCount">每套中的書籍數量</param>
        /// <returns>折扣數</returns>
        private decimal GetDisount(int bookCount)
        {
            return _discountMap[bookCount];
        }
    }
}