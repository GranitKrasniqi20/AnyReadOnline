using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class PublishHouse : Audit, IPublishHouse
    {
        public int PublishHouseID { get ; set; }
        public string PublishHouseName { get; set; }
    }
}
