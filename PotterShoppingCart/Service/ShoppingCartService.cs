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

        public int GetPotterSerialTotalPrice(Order order)
        {
            return order.Details.Sum(p => p.Key.Price * p.Value);
        }
    }
}