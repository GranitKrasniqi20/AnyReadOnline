using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Staff : User
    {
        public string UserName { get; set; }
        public virtual Role Role { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public Staff()
        {
            Country = new Country();
            Role = new Role();
        }
    }
}
