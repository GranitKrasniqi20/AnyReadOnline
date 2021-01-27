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
    public class AddressBLL : ICrud<Address>
    {
        private readonly AddressDAL addressDAL = new AddressDAL();
        private readonly CountryDAL countryDAL = new CountryDAL();

        public int Add(Address obj)
        {
            return addressDAL.Add(obj);
        }

        public int Delete(int id)
        {
            return addressDAL.Delete(id);
        }

        public Address Get(int id)
        {
            return addressDAL.Get(id);
        }

        public List<Address> GetAll()
        {
            return addressDAL.GetAll().ToList();
        }

        public int Update(Address obj)
        {
            return addressDAL.Update(obj);
        }
    }
}
