using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Client : User
    {
        public Gender Gender { get; set; }

        //public List<IOrder> orders;
        //public List<Address> addresses;
        //public List<IPayment> payments;
    }
}
