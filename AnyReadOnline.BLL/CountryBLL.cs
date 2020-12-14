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
        private readonly CountryDAL countryDAL = new CountryDAL();

        public int Add(Country obj)
        {
            return countryDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return countryDAL.Delete(id);
        }

        public Country Get(int id)
        {
            return countryDAL.Get(id);
        }

        public List<Country> GetAll()
        {
            return countryDAL.GetAll();
        }

        public int Update(Country obj)
        {
            return countryDAL.Update(obj);
        }
    }
}
