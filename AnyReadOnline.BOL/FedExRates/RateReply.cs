using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.FedExRates
{
    public class RateReply
    {
        public string ServiceType { get; set; }
        public string PackagingType { get; set; }
        public List<RatedShipmentDetails> RatedShipmentDetails { get; set; } = new List<RatedShipmentDetails>();
    }
}
