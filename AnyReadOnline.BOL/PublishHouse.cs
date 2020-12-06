using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class PublishHouse : Audit, IPublishHouse
    {
        public int PublishHouseID { get ; set; }
        public string PublishHouseName { get; set; }
    }
}
