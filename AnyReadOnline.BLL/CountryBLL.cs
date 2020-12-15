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
    public class CountryBLL : ICrud<Country>
    {
        private readonly CountryDAL CountryDAL = new CountryDAL();

        public int Add(Country obj)
        {
            return CountryDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return CountryDAL.Delete(id);
        }

        public Country Get(int id)
        {
            return CountryDAL.Get(id);
        }

        public List<Country> GetAll()
        {
            return CountryDAL.GetAll();
        }

        public int Update(Country obj)
        {
            return CountryDAL.Update(obj);
        }



    }
}
