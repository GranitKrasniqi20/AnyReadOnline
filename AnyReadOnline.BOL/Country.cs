using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyReadOnline.BOL.Interfaces;

namespace AnyReadOnline.BOL
{
    public class Country : Audit, ICountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
