using ANYREAD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Order : IOrder
    {
        public int OrderID { get; set; }
        public virtual IClient Client { get; set; }
        public int ClientID { get; set; }
        public int ShippingAddressID { get; set; }
        public virtual IAddress ShippingAddress { get; set; }
        public double ShippingFee { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int ShippingCompanyID { get; set; }
        // public virtual  IShippingCompany ShippingCompany { get; set; }

    }
}
