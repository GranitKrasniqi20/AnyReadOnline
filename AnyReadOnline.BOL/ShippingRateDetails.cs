﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
   public class ShippingRateDetails
    {
        public string RateType { get; set; }
        public double TotalBillingWeight { get; set; }
        public double TotalBaseCharge { get; set; }
        public double TotalSurcharges { get; set; }


    }
}