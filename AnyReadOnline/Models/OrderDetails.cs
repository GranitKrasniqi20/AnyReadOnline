using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int BookID { get; set; }
        public virtual  IBook Book { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public virtual IOrder Order { get; set; }

    }
}
