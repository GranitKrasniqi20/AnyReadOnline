using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string BitcoinAddress { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public int BillingAddresID { get; set; }
        public virtual IAddress Address { get; set; }
        public double TotalFee { get; set; }

    }
}
