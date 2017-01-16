using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PotterShoppingCart.Interface;

namespace PotterShoppingCart.Domain
{
    /// <summary>
    /// 計算一次購買1本HarryPotter的折扣
    /// </summary>
    public class PackOf1PotterDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 1M;
        }
    }
}
