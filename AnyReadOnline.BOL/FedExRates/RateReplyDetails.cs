using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.FedExRates
{
   public class RateReplyDetails
    {
        public List<RateReply> RateReplies { get; set; } = new List<RateReply>();
        public DateTime DeliveryTimestamp { get; set; }
        public string TransitTime { get; set; }
    }
}
