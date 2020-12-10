using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class OrderDetails : Audit
    {
        public int OrderDetailsID { get; set; }
        public int BookID { get; set; }
        public virtual  Book Book { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

    }
}
