using ANYREAD.Models.Interfaces;
using System;

namespace ANYREAD.Models
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