using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL.Interfaces
{
    public interface IPublishHouse
    {
        int PublishHouseID { get; set; }
        string PublishHouseName { get; set; }
    }
}