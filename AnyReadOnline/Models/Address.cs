using ANYREAD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANYREAD.Models
{
    public class Address : IAddress
    {
        public int AddressID { get; set; }
        public int ClientID { get; set; }
        public virtual IClient Client { get; set; }
        public int CountryID { get; set; }
        public virtual ICountry Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }



    }

}