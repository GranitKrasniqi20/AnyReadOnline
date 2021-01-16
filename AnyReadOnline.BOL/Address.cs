using AnyReadOnline.BOL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyReadOnline.BOL
{
    public class Address : Audit
    {
        //public Address()
        //{
        //    Client = new Client();
        //    Country = new Country();
        //}

        public int AddressID { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }


}