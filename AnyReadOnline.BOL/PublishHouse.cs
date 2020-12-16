using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class PublishHouse : Audit
    {
        public int PublishHouseID { get ; set; }

        [Required]
        [StringLength(50)]
        public string PublishHouseName { get; set; }
    }
}
