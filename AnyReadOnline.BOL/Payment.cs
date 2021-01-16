using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.BOL.FedExRates;

namespace AnyReadOnline.BOL
{
    public class Payment : Audit
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public string BitcoinAddress { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public int BillingAddresID { get; set; }
        public virtual Address BillingAddres { get; set; }
        public double TotalFee { get; set; }
        public RateReplyDetails ratedShipmentDetails  { get; set; }
        public double Subtotal { get; set; }
        public double TotalPrice { get; set; }
        public bool clientConfirmation { get; set; }
    }
}
