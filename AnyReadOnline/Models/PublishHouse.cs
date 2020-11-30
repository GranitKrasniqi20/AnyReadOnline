using AnyReadOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class PublishHouse : Audit, IPublishHouse
    {
        public string publishHouse { get ; set; }
        public int PublishHouseID { get ; set; }
    }
}
