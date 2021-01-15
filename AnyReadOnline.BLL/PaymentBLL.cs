using AnyReadOnline.BOL;
using AnyReadOnline.BOL.FedExRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BLL
{
    public class PaymentBLL
    {
        public double CalculatePrice(List<OrderDetails> orderDetails, double shippingCost )
        {
            double finalPrice = 0 ;
            foreach (var item in orderDetails)
            {
                finalPrice += shippingCost+(double)item.Book.Price * item.Quantity  ;
            }
            return finalPrice;
        }

    }
}
