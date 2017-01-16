using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PotterShoppingCart.Interface;

namespace PotterShoppingCart.Domain
{
    /// <summary>
    /// 計算一次購買4本HarryPotter的折扣
    /// </summary>
    public class PackOf4PotterDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 0.8M;
        }
    }
}
