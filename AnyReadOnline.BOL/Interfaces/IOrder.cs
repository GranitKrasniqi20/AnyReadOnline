using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IOrder
    {
        DateTime ArrivalDate { get; set; }
        IClient Client { get; set; }
        int ClientID { get; set; }
        int OrderID { get; set; }
        IAddress ShippingAddress { get; set; }
        int ShippingAddressID { get; set; }
        int ShippingCompanyID { get; set; }
        double ShippingFee { get; set; }
    }
}