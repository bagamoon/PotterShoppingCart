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

        public decimal GetPotterSerialTotalPrice(Order order)
        {
            decimal totalPrice = 0;
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