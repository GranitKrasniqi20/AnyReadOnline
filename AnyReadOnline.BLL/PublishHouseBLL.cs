using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using AnyReadOnline.DAL;

namespace AnyReadOnline.BLL
{
    public class PublishHouseBLL : ICrud<PublishHouse>
    {
        private readonly PublishHouseDAL publishHouseDAL = new PublishHouseDAL();

        public int Add(PublishHouse obj)
        {
            return publishHouseDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return publishHouseDAL.Delete(id);
        }

        public PublishHouse Get(int id)
        {
            return publishHouseDAL.Get(id);
        }

        public List<PublishHouse> GetAll()
        {
            return publishHouseDAL.GetAll();
        }

        public int Update(PublishHouse obj)
        {
            return publishHouseDAL.Update(obj);
        }
    }
}
