using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.Models.Interfaces;

namespace AnyReadOnline.Models
{
    public class OrderDetails : Audit
    {
        public int OrderDetailsID { get; set; }
        public int BookID { get; set; }
        public virtual  IBook Book { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public virtual IOrder Order { get; set; }

    }
}
