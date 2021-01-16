using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BLL
{
    class OrderDetailsBLL 
    {
        private readonly OrderDetailsDAL OrderDetailsDAL = new OrderDetailsDAL();

        public int Add(OrderDetails obj)
        {
            return OrderDetailsDAL.Add(obj);
        }


        public OrderDetails Get(int id)
        {
            return OrderDetailsDAL.Get(id);
        }



    }
}
