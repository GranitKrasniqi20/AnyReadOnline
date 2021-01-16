using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BLL
{
    public class OrderBLL 
    {
        private readonly OrderDAL orderDAL = new OrderDAL();


        public int Add(Payment payment)
        {
            payment.Order.ShippingFee = payment.ratedShipmentDetails.RateReplies[0].RatedShipmentDetails[0].TotalBillingAmount;
            payment.Order.ShippingAddress.AddressID = 1; 
            int orderid = orderDAL.Add(payment.Order);
            if (orderid > 0)
            {
                OrderDetailsBLL orderDetails = new OrderDetailsBLL();
                foreach (var item in payment.Order.OrderDetails)
                {
                    item.OrderID = orderid;
                    orderDetails.Add(item);
                }


                payment.OrderID = orderid;
                PaymentBLL paymentBLL = new PaymentBLL();
                paymentBLL.Add(payment);

                return 1;

            }

            return 0;
        }







       public List<Order> GetAllByClientId()
        {
            return orderDAL.GetAll();
        }
    }
}
