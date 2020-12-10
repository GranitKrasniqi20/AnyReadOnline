using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Order : Audit
    {
        public int OrderID { get; set; }
        public virtual Client Client { get; set; }
        public int ClientID { get; set; }
        public int ShippingAddressID { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public double ShippingFee { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int ShippingCompanyID { get; set; }
        // public virtual  IShippingCompany ShippingCompany { get; set; }

    }
}
