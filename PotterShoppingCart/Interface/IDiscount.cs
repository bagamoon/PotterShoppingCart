using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Interface
{
    public interface IDiscount
    {
        /// <summary>
        /// 取得購買書籍時的折扣數
        /// </summary>
        /// <returns>折扣數(小數), 如70%以0.7表示</returns>
        decimal GetDiscount();
    }
}
