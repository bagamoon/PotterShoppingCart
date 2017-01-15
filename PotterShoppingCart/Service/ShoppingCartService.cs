using System;
using System.Collections.Generic;
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
            if (order.Details.Keys.Count == 1)
            {
                totalPrice = order.Details.Sum(p => p.Key.Price * p.Value);
            }
            else if (order.Details.Keys.Count == 2)
            {
                int pair = order.Details.Values.Min();
                decimal pairPrice = pair * order.Details.Sum(p => p.Key.Price) * 0.95M;
                decimal restPrice = order.Details.Sum(p => p.Key.Price * (p.Value - pair));
                totalPrice = pairPrice + restPrice;
            }

            //佛心老闆使用無條件捨去
            return Math.Floor(totalPrice);
        }
    }
}