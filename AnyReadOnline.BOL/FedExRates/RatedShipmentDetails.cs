using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.FedExRates
{
   public class RatedShipmentDetails
    {
        public string RateType { get; set; }
        public double TotalBillingAmount { get; set; }
        public string Currency { get; set; }
        public double TotalBaseChargeAmount { get; set; }
        public double TotalFreightDiscountsAmount { get; set; }
        public double TotalSurchargesAmount { get; set; }
       public List<Surcharges> surcharges = new List<Surcharges>();
        public double TotalNetCharge { get; set; }
    }
}
