using AnyReadOnline.BOL;
using AnyReadOnline.BOL.FedExRates;
using AnyReadOnline.DAL;
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

            return CalculateSubtotal(orderDetails) + shippingCost;
        }

        public int Add(Payment payment)
        {
            PaymentDAL paymentDAL = new PaymentDAL();

          return  paymentDAL.Add(payment);
        }

        public double CalculateSubtotal(List<OrderDetails> orderDetails)
        {
            double finalPrice = 0;
            foreach (var item in orderDetails)
            {
                finalPrice += (double)item.Book.Price * item.Quantity;
            }
            return finalPrice;
        }

    }
}
