using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class CartItemModel
    {
        public int ClientID { get; set; }
        public Book book { get; set; }
        public int Quantity { get; set; }
    }
}
