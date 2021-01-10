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
    class OrderBLL : ICrud<Order>
    {
        private readonly OrderDAL orderDAL = new OrderDAL();


        public int Add(Order obj)
        {
            return orderDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return orderDAL.Delete(id);
        }

        public int Update(Order obj)
        {
            return orderDAL.Update(obj);
        }

        Order IRead<Order>.Get(int id)
        {
            return orderDAL.Get(id);
        }

        List<Order> IRead<Order>.GetAll()
        {
            return orderDAL.GetAll();
        }
    }
}
