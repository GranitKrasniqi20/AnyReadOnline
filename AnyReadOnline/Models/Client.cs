﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class Client:User,IClient
    {

        //public List<IOrder> orders;
        //public List<IAddress> addresses;
        //public List<IPayment> payments;
        public void Genderr()
        {
            this.Gender = Gender.Female;
        }
    }
}
